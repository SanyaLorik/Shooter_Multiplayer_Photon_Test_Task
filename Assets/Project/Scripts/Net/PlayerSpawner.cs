using Photon.Pun;
using UnityEngine;

namespace Shooter
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnpoints;
        [SerializeField] private GameObject _player;

        private void Start()
        {
            var spawnpoint = _spawnpoints[PhotonNetwork.CountOfPlayers - 1];
            PhotonNetwork.Instantiate(_player.name, spawnpoint.position, spawnpoint.rotation);
        }
    }
}
