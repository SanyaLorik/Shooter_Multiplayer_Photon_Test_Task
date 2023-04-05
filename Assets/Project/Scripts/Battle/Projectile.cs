using UnityEngine;

namespace Shooter
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField][Range(0f, 10f)] private float _force;
        [SerializeField][Min(0)] private float _damage;

        public void Launch(Vector2 direction)
        {
            _rigidbody.AddForce(direction * _force, ForceMode2D.Impulse);
        }
    }
}
