using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class Locator : MonoBehaviour
    {
        [Header("Player Input")]
        [SerializeField] private UiInput _input;

        public static Locator Instance { get; private set; }

        private readonly IDictionary<Type, object> _values = new Dictionary<Type, object>();

        private void Awake()
        {
            Instance ??= this;

            BindDirection();
            BindShooting();
        }

        public T Solve<T>()
        {
            return (T)_values[typeof(T)];
        }

        private void Register<T>(T value)
        {
            _values.Add(typeof(T), value);
        }

        private void BindDirection()
        {
            IDirection direction = _input;
            Register(direction);
        }

        private void BindShooting()
        {
            IShootingObservable shooting = _input;
            Register(shooting);
        }
    }
}
