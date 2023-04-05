using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class UiNickname : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private Text _nickname;

        private void Awake()
        {
            _nickname.text = _view.Owner.NickName;
        }
    }
}
