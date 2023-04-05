using Photon.Pun;
using System;
using UnityEngine;

namespace Shooter
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class CoinCollector : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;

        public event Action<int> OnReplenished;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_view.IsMine == false)
                return;

            if (collision.transform.TryGetComponent(out Coin coin) == false)
                return;

            Counter++;
            OnReplenished?.Invoke(Counter);
            coin.Collecte();
        }

        public int Counter { get; private set; }
    }
}
