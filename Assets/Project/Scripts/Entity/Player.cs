using System;
using UnityEngine;

namespace Shooter
{
    public class Player : MonoBehaviour, IDamageable<float>
    {
        [SerializeField][Min(0)] private float _health;

        public event Action<float> OnHealthChangedAsPercent;

        private float _maxHealth;

        private void Awake()
        {
            _maxHealth = _health;
        }

        public void Damage(float value)
        {
            if (_health <= 0)
                return;

            _health -= _health - value > 0 ? value : _health;
            float percent = _health / _maxHealth;

            OnHealthChangedAsPercent?.Invoke(percent);
        }
    }
}
