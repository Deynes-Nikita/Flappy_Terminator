using TMPro;
using UnityEngine;

namespace Flappy_Terminator
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TextMeshProUGUI _text;

        private void OnEnable()
        {
            _player.Health—hanged += ShowHealth;
        }

        private void OnDisable()
        {
            _player.Health—hanged += ShowHealth;
        }

        private void ShowHealth(int value)
        {
            _text.text = value.ToString();
        }
    }
}
