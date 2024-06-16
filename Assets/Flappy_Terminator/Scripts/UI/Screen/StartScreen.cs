using System;

namespace Flappy_Terminator
{
    public class StartScreen : Screen
    {
        public event Action PlayButtonClicked;

        protected override void OnButtonClick()
        {
            PlayButtonClicked?.Invoke();
        }
    }
}
