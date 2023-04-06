using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class UiScore : MonoBehaviour
    {
        [SerializeField] private Text _score;

        public void SetScore(int score)
        {
            _score.text = score.ToString();
        }
    }
}
