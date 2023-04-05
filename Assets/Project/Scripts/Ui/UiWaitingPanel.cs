using Photon.Pun;
using System.Collections;
using UnityEngine;

namespace Shooter
{
    public class UiWaitingPanel : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject _panel;

        private const int _minPlayer = 2;

        private void Start()
        {
            if (PhotonNetwork.CountOfPlayers >= _minPlayer)
                _panel.SetActive(false);
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            _panel.SetActive(false);
        }
    }
}
