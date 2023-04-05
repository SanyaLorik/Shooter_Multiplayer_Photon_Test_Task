using Photon.Pun;
using UnityEngine;

namespace Shooter
{
    [RequireComponent(typeof(PhotonView))]
    public class PlayerWrapper : MonoBehaviour
    {
        [field: SerializeField] public Player Player { get; private set; }
    }
}
