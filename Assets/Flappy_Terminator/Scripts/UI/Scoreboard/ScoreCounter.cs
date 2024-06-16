using System;
using UnityEngine;

namespace Flappy_Terminator
{
    public class ScoreCounter : MonoBehaviour
    {
        private int _score;

        public event Action<int> ScoreChanged;

        public void Add(int value)
        {
            _score += value;
            ScoreChanged?.Invoke(_score);
        }

        public void Reset()
        {
            _score = 0;
            ScoreChanged?.Invoke(_score);
        }
    }
}
