using Photon.Pun;
using System.Linq;
using UnityEngine;

namespace Shooter
{
    public class GameOver : MonoBehaviour
    {
        [Header("Envoriment")]
        [SerializeField] private PhotonView _view;
        [SerializeField] private PlayerSpawner _spawner;

        [Header("Ui")]
        [SerializeField] private UiGameOver _ui;

        private PlayerWrapper[] _players = new PlayerWrapper[4];

        private void OnEnable()
        {
            _spawner.OnSpawned += OnAdded;
        }

        private void OnDisable()
        {
            _spawner.OnSpawned -= OnAdded;

            if (_players[0] != null)
                Unbind();
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
            var winners = _players.Where(i => i.Player.IsAlive == true);
            if (winners.Count() > 1)
                return;

            var winner = winners.FirstOrDefault();
            _view.RPC(nameof(Over), RpcTarget.All);
        }

        [PunRPC]
        private void Over()
        {
            _ui.Show();
        }
    }
}
