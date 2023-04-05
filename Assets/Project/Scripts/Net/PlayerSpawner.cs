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
            for (int i = 0; i < PhotonNetwork.PlayerList.Length - 1; i++)
            {
                var spawnpoint = _spawnpoints[i];
                PhotonNetwork.Instantiate(_player.name, spawnpoint.position, spawnpoint.rotation);
            }
        }
    }
}
