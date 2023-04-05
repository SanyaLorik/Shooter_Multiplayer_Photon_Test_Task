using Photon.Pun;
using UnityEngine;

namespace Shooter
{
    public class VecolocityMovement : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField][Range(0f, 10f)] private float _speed;

        private IDirection _direction;

        private void Start()
        {
            _direction = Locator.Instance.Get<IDirection>();
        }

        private void FixedUpdate()
        {
            if (_view.IsMine == true)
                _rigidbody.velocity = _direction.Direction * _speed;
        }
    }
}
