using UnityEngine;
using UnityEngine.UI;

namespace Shooter
{
    public class UiHealth : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Image _healthbar;

        private void OnEnable()
        {
            _player.OnHealthChangedAsPercent += OnChange;
        }

        private void OnDisable()
        {
            _player.OnHealthChangedAsPercent -= OnChange;
        }

        private void OnChange(float percent)
        {
            _healthbar.fillAmount = percent;
        }
    }
}
