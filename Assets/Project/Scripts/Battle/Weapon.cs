using Photon.Pun;
using UnityEngine;

namespace Shooter
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private Projectile _projectile;

        private IShootingObservable _shootingObservable;

        private void Awake()
        {
            _shootingObservable = Locator.Instance.Solve<IShootingObservable>();
            print(_shootingObservable);
        }

        private void OnEnable()
        {
            _shootingObservable.OnShooted += OnShoot;
        }

        private void OnDisable()
        {
            _shootingObservable.OnShooted -= OnShoot;
        }

        private void OnShoot()
        {
            if (_view.IsMine == false)
                return;

            var projectile = PhotonNetwork
                .Instantiate(_projectile.name, transform.position + transform.up, Quaternion.identity)
                .GetComponent<Projectile>();

            projectile.Launch(transform.up);

            Debug.Log("Shoot!");
        }
    }
}
