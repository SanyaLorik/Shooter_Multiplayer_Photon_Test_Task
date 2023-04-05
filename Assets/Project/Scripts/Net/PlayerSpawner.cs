using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine;

namespace Shooter
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private Transform[] _spawnpoints;
        [SerializeField] private GameObject _player;

        private int _counter = 0;

        private void Start()
        {
            var spawnpoint = _spawnpoints[PhotonNetwork.CountOfPlayers -1];
            PhotonNetwork.Instantiate(_player.name, spawnpoint.position, spawnpoint.rotation);
            _counter++;
        }
    }
}
