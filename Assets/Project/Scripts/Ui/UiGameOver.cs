using Photon.Pun;
using UnityEngine;

namespace Shooter
{
    public class UiGameOver : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private GameObject _panel;

        public void Show()
        {
            _view.RPC(nameof(ShowOver), RpcTarget.AllBuffered);
        }

        [PunRPC]
        private void ShowOver()
        {
            _panel.SetActive(true);
        }
    }
}
