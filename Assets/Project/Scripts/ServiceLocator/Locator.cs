using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class Locator : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;

        public static Locator Instance { get; private set; }

        private readonly IDictionary<Type, object> _values = new Dictionary<Type, object>();

        private void Awake()
        {
            Instance ??= this;
            BindDirection();
        }

        public T Get<T>()
        {
            return (T)_values[typeof(T)];
        }

        private void Add<T>(T value)
        {
            _values.Add(typeof(T), value);
        }

        private void BindDirection()
        {
            IDirection direction = _joystick;
            Add(direction);
        }
    }
}
