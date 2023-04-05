using System;
using UnityEngine;

namespace Shooter
{
    [RequireComponent(typeof(Collider2D))]
    public class Coin : MonoBehaviour
    {
        public event Action OnCollected;

        public void Collecte()
        {
            OnCollected?.Invoke();
        }
    }
}
