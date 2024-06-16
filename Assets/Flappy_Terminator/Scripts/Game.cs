using UnityEngine;

namespace Flappy_Terminator
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private StartScreen _startScreen;
        [SerializeField] private GameOverScreen _gameOverScreen;

        private void OnEnable()
        {
            _startScreen.PlayButtonClicked += OnPlayButtonClick;
            _gameOverScreen.RestartButtonClicked += OnRestartButtonClick;
            _player.GameOver += OnGameOver;
        }

        private void OnDisable()
        {
            _startScreen.PlayButtonClicked -= OnPlayButtonClick;
            _gameOverScreen.RestartButtonClicked -= OnRestartButtonClick;
            _player.GameOver -= OnGameOver;
        }

        private void Start()
        {
            Time.timeScale = 0;
            _gameOverScreen.Close();
            _startScreen.Open();
        }

        private void OnGameOver()
        {
            Time.timeScale = 0;
            _gameOverScreen.Open();
        }

        private void OnRestartButtonClick()
        {
            _gameOverScreen.Close();
            StartGame();
        }
        private void OnPlayButtonClick()
        {
            _startScreen.Close();
            StartGame();
        }

        private void StartGame()
        {
            Time.timeScale = 1;
            _player.ResetParemetrs();
            _enemySpawner.Restart();
            _scoreCounter.Reset();
        }
    }
}
