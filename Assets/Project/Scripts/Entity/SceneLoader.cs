using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shooter
{
    public class SceneLoader : MonoBehaviour 
    {
        [SerializeField][Min(0)] private int _game;
        [SerializeField][Min(0)] private int _loading;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnDelete;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded += OnDelete;
        }

        public void LoadGame()
        {
            SceneManager.LoadSceneAsync(_loading);
            PhotonNetwork.LoadLevel(_game);
        }

        private void OnDelete(Scene scene, LoadSceneMode _)
        {
            if (scene.buildIndex == _game)
                Destroy(this);
        }
    }
}
