using Photon.Pun;
using System;
using UnityEngine;

namespace Shooter
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnpoints;
        [SerializeField] private GameObject _playerPrefab;

        public event Action<PlayerWrapper> OnSpawned;

        private void Start()
        {
            var spawnpoint = _spawnpoints[PhotonNetwork.CountOfPlayers - 1];
            var player = PhotonNetwork
                .Instantiate(_playerPrefab.name, spawnpoint.position, spawnpoint.rotation)
                .GetComponent<PlayerWrapper>();

            OnSpawned?.Invoke(player);
        }
    }
}
