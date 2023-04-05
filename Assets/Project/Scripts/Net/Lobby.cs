using Photon.Pun;
using Photon.Realtime;
using Shooter;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter.Net
{
    public class Lobby : MonoBehaviourPunCallbacks
    {
        [Header("Scene")]
        [SerializeField] private int _idGameScene;

        [Header("Creation")]
        [SerializeField] private InputField _creationField;
        [SerializeField] private Button _creationButton;

        [Header("Connection")]
        [SerializeField] private InputField _connectionField;
        [SerializeField] private Button _connectionButton;

        private const string _region = "ru";
        private const int _maxPlayerInRoom = 4;

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

        public override void OnDisable()
        {
            base.OnDisable();

            _creationButton.onClick.RemoveListener(OnCreateRoom);
            _connectionButton.onClick.RemoveListener(OnConnectionToRoom);
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log($"Connected to region: {PhotonNetwork.CloudRegion}!");
            if (PhotonNetwork.InLobby == false)
                PhotonNetwork.JoinLobby();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("Disconnected!");
        }

        public override void OnCreatedRoom()
        {
            Debug.Log($"Romm is created: {PhotonNetwork.CurrentRoom.Name}.");
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.Log($"Romm is not created! Code: {returnCode}. Message: {message}.");
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Load Game level.");
            PhotonNetwork.LoadLevel(_idGameScene);
        }

        private void OnCreateRoom()
        {
            if (PhotonNetwork.IsConnectedAndReady == false)
                return;

            string name = _creationField.text;
            if (name.IsCorrectNameRoom() == false)
                return;

            RoomOptions options = new() { MaxPlayers = _maxPlayerInRoom };
            bool isCreated = PhotonNetwork.CreateRoom(name, options, TypedLobby.Default);
            if (isCreated == false)
            {
                Debug.Log($"Romm is not created! isCreated: {isCreated}");
                return;
            }

            Debug.Log("Load Game level.");
        }

        private void OnConnectionToRoom()
        {
            string name = _connectionField.text;
            if (name.IsCorrectNameRoom() == false)
                return;

            PhotonNetwork.JoinRoom(name);
        }
    }
}
