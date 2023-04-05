using Photon.Pun;
using UnityEngine;

namespace Shooter
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        //[SerializeField] private PhotonView _view;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField][Range(0f, 10f)] private float _force;
        [SerializeField][Min(0)] private float _damage;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //_view.RPC(nameof(DestroySelf), RpcTarget.All, gameObject);
            PhotonNetwork.Destroy(gameObject);
        }

        public void Launch(Vector2 direction)
        {
            _rigidbody.AddForce(direction * _force, ForceMode2D.Impulse);
        }
        /*
        [PunRPC]
        private void DestroySelf(GameObject go)
        {
            PhotonNetwork.Destroy(gameObject);
        }*/
    }
}
