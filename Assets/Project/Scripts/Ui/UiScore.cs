using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class UiScore : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private Text _score;

        public void SetScore(int score)
        {
            _view.RPC(nameof(SetScoreRPC), RpcTarget.AllBuffered, score);
        }

        [PunRPC]
        private void SetScoreRPC(int score)
        {
            _score.text = score.ToString();
        }
    }
}
