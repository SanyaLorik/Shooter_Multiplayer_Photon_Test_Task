using Photon.Pun;
using UnityEngine;

namespace Shooter
{
    public class CoinPlacer : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private Coin _coin;
        [SerializeField] private Transform[] _points;

        private void OnEnable()
        {
            _coin.OnCollected += OnMove;
        }

        private void OnDisable()
        {
            _coin.OnCollected -= OnMove;
        }

        private void OnMove()
        {
            var point = _points[Random.Range(0, _points.Length)].position;
            _view.RPC(nameof(Move), RpcTarget.AllBuffered, point.x, point.y);
        }

        [PunRPC]
        private void Move(float x, float y)
        {
            _coin.transform.position = new Vector3(x, y);
        }
    }
}
