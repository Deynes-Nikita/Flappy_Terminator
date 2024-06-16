using TMPro;
using UnityEngine;

namespace Flappy_Terminator
{
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private TextMeshProUGUI _text;

        private void OnEnable()
        {
            _scoreCounter.ScoreChanged += ShowScore;
        }

        private void OnDisable()
        {
            _scoreCounter.ScoreChanged += ShowScore;
        }

        private void ShowScore(int value)
        {
            _text.text = value.ToString();
        }
    }
}
