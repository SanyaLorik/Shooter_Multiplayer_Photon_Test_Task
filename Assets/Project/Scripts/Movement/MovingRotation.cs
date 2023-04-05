using Photon.Pun;
using UnityEngine;

namespace Shooter
{
    public class MovingRotation : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private Rigidbody2D _rigidbody;

        private IDirection _direction;

        private void Start()
        {
            _direction = Locator.Instance.Get<IDirection>();
        }

        private void FixedUpdate()
        {
            if (_view.IsMine == false)
                return;

            if (_direction.Direction == Vector2.zero)
            {
                _rigidbody.angularVelocity = 0;
                return;
            }

            var angle = -Vector2.SignedAngle(_direction.Direction, Vector2.up);
            _rigidbody.MoveRotation(angle);
        }
    }
}
