using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shooter
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private PlayerSpawner _spawner;

        private IList<PlayerWrapper> _players = new List<PlayerWrapper>();

        private void OnEnable()
        {
            _spawner.OnSpawned += OnAdded;
        }

        private void OnDisable()
        {
            _spawner.OnSpawned -= OnAdded;
        }

        private void OnAdded(PlayerWrapper player)
        {
            _view.RPC(nameof(Add), RpcTarget.AllBuffered);
        }

        [PunRPC]
        private void Add()
        {
            _players = FindObjectsOfType<PlayerWrapper>().ToList();
            print(_players.Count);
        }
    }
}
