using Photon.Pun;
using System.Collections;
using UnityEngine;

namespace Shooter
{
    public class UiWaitingPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        private const int _minPlayer = 2;

        private IEnumerator Start()
        {
            yield return new WaitWhile(() => PhotonNetwork.PlayerList.Length < _minPlayer);
            _panel.SetActive(false);
        }
    }
}
