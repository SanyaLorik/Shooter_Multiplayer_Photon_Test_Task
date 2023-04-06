using Photon.Pun;
using UnityEngine;

namespace Shooter
{
    public class PlayerColorChanger : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private SpriteRenderer[] _spriteRenderers;
        [SerializeField] private Color[] _colors;

        private void Start()
        {
            var color = _colors[PhotonNetwork.CountOfPlayers - 1];
            _view.RPC(nameof(Change), RpcTarget.AllBuffered, color.r, color.g, color.b, color.a);
        }

        [PunRPC]
        private void Change(float r, float g, float b, float a)
        {
            foreach (var spriteRenderer in _spriteRenderers)
                spriteRenderer.color = new Color(r, g, b, a);
        }
    }
}
