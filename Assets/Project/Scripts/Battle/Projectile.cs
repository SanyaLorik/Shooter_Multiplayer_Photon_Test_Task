using Photon.Pun;
using UnityEngine;

namespace Shooter
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField][Range(0f, 10f)] private float _force;
        [SerializeField][Min(0)] private float _damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_view.IsMine == false)
                return;

            if (collision.TryGetComponent(out IDamageable<float> damage) == true)
                damage.Damage(_damage);

            PhotonNetwork.Destroy(gameObject);
        }

        public void Launch(Vector2 direction)
        {
            _rigidbody.AddForce(direction * _force, ForceMode2D.Impulse);
        }
    }
}
