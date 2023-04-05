using UnityEngine;

namespace Shooter
{
    public class Weapon : MonoBehaviour
    {
        private IShootingObservable _shootingObservable;

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
            Debug.Log("Shoot!");
        }
    }
}
