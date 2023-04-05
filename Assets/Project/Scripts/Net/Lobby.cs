using StudentProfileUnity;
using UnityEngine;
using UnityEngine.UI;

namespace Shooter.Net
{
    public class Lobby : MonoBehaviour
    {
        [Header("Creation")]
        [SerializeField] private InputField _creationField;
        [SerializeField] private Button _creationButton;

        [Header("Connection")]
        [SerializeField] private InputField _connectionField;
        [SerializeField] private Button _connectionButton;

        private void OnEnable()
        {
            _creationButton.onClick.AddListener(OnCreateRoom);
            _connectionButton.onClick.AddListener(OnConnectionToRoom);
        }

        private void OnDisable()
        {
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
