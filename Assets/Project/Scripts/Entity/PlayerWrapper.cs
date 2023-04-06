using Photon.Pun;
using UnityEngine;

namespace Shooter
{
    [RequireComponent(typeof(PhotonView))]
    public class PlayerWrapper : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;

        [field: SerializeField] public Player Player { get; private set; }

        private void OnEnable()
        {
            Player.OnDeid += OnDied;
        }

        private void OnDisable()
        {
            Player.OnDeid -= OnDied;
        }

        private void OnDied()
        {
            _view.RPC(nameof(Die), RpcTarget.AllBuffered);
        }

        [PunRPC]
        private void Die()
        {
            gameObject.SetActive(false);
        }
    }
}
