using Photon.Pun;
using Photon.Realtime;
using StudentProfileUnity;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter.Net
{
    public class Lobby : MonoBehaviourPunCallbacks
    {
        [Header("Photon")]
        [SerializeField] private string _region;

        [Header("Creation")]
        [SerializeField] private InputField _creationField;
        [SerializeField] private Button _creationButton;

        [Header("Connection")]
        [SerializeField] private InputField _connectionField;
        [SerializeField] private Button _connectionButton;

        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.ConnectToRegion(_region);
        }

        public override void OnEnable()
        {
            base.OnEnable();

            _creationButton.onClick.AddListener(OnCreateRoom);
            _connectionButton.onClick.AddListener(OnConnectionToRoom);
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log($"Connected to: {PhotonNetwork.CloudRegion}!");
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("Disconnected!");
        }

        public override void OnDisable()
        {
            base.OnDisable();

            _creationButton.onClick.RemoveListener(OnCreateRoom);
            _connectionButton.onClick.RemoveListener(OnConnectionToRoom);
        }

        private void OnCreateRoom()
        {
            string name = _creationField.text;
            if (name.IsCorrectNameRoom() == false)
                return;
        }

        private void OnConnectionToRoom()
        {
            string name = _connectionField.text;
            if (name.IsCorrectNameRoom() == false)
                return;
        }
    }
}
