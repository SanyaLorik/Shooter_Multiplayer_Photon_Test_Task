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
            Vector3 position;
            do
                position = _points[Random.Range(0, _points.Length)].position;
            while (position == _coin.transform.position);

            _view.RPC(nameof(Move), RpcTarget.AllBuffered, position);
        }

        [PunRPC]
        private void Move(Vector3 position)
        {
            _coin.transform.position = position;
        }
    }
}
