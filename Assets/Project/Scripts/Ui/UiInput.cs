using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class UiInput : MonoBehaviour, IDirection, IShootingObservable
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _shooting;

        public event Action OnShooted;

        private void OnEnable()
        {
            _shooting.onClick.AddListener(OnShoot);
        }

        private void OnDisable()
        {
            _shooting.onClick.RemoveListener(OnShoot);
        }

        public Vector2 Direction => _joystick.Direction;

        private void OnShoot()
        {
            OnShooted?.Invoke();
        }
    }
}
