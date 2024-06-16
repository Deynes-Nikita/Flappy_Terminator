using System;

namespace Flappy_Terminator
{
    public class GameOverScreen : Screen
    {
        public event Action RestartButtonClicked;

        protected override void OnButtonClick()
        {
            RestartButtonClicked?.Invoke();
        }
    }
}
