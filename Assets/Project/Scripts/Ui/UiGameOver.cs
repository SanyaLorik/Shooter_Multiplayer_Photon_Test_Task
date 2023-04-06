using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class UiGameOver : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private GameObject _panel;
        [SerializeField] private Text _nickname;
        [SerializeField] private Text _score;

        public void Show(string nickname, int score)
        {
            _view.RPC(nameof(ShowOver), RpcTarget.AllBuffered, nickname, score);
        }

        [PunRPC]
        private void ShowOver(string nickname, int score)
        {
            _panel.SetActive(true);

            _nickname.text =  $"Ник: {nickname}";
            _score.text = $"Счет: {score}"; ;
        }
    }
}
