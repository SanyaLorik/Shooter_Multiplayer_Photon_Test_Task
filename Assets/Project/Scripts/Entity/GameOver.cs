using Photon.Pun;
using System;
using UnityEngine;

namespace Shooter
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private PhotonView _view;
        [SerializeField] private PlayerSpawner _spawner;

        private PlayerWrapper[] _players = new PlayerWrapper[4];

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
            if (_players[0] != null)
                Unbind();

            _players = FindObjectsOfType<PlayerWrapper>();
            Bind();

            print(_players.Length);
        }

        private void Bind()
        {
            foreach (var player in _players)
                player.Player.OnDeid += OnOver;
        }

        private void Unbind()
        {
            foreach (var player in _players)
                player.Player.OnDeid -= OnOver;
        }

        private void OnOver()
        {
            print("died!");
        }
    }
}
