using System;
using UnityEngine;

namespace Shooter
{
    public class Player : MonoBehaviour, IDamageable<float>
    {
        [SerializeField][Min(0)] private float _health;

        [field: SerializeField] public CoinCollector Collector { get; private set; }

        public event Action<float> OnHealthChangedAsPercent;
        public event Action OnDeid;

        private float _maxHealth;

        private void Awake()
        {
            _maxHealth = _health;
        }

        public bool IsAlive => _health > 0;

        public void Damage(float value)
        {
            if (_health <= 0)
                return;

            _health = Mathf.Clamp(_health - value, 0, _maxHealth);
            float percent = _health / _maxHealth;

            OnHealthChangedAsPercent?.Invoke(percent);

            if (_health <= 0)
                OnDeid?.Invoke();
        }
    }
}
