using Photon.Pun;
using UnityEngine;

namespace Shooter
{
    public class PlayerColorChanger : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private SpriteRenderer[] _spriteRenderers;
        [SerializeField] private Color[] _colors;
        [SerializeField] private RpcTarget _rpcTarget;

        private void Start()
        {
            var color = _colors[PhotonNetwork.CountOfPlayers - 1];
            var v =  PhotonView.Get(this);
            Change(color.r, color.g, color.b, color.a);
            //v.RPC("Change", _rpcTarget, color.r, color.g, color.b, color.a);
            //v.RPC("Change", RpcTarget.AllBuffered, 4f, 4f, 4f, 4f);
        }

        [PunRPC]
        private void Change(float r, float g, float b, float a)
        {
            foreach (var spriteRenderer in _spriteRenderers)
                spriteRenderer.color = new Color(r, g, b, a);
        }
       
        /*
        private void Change(Color color)
        {
            foreach (var spriteRenderer in _spriteRenderers)
                spriteRenderer.color = color;
        }
        */
    }
}
