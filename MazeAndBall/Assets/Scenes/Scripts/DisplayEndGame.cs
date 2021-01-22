using UnityEngine;
using UnityEngine.UI;


namespace MazeAndBall
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;

        public DisplayEndGame(Text finishGameLabel)
        {
            _finishGameLabel = finishGameLabel;
            _finishGameLabel.text = string.Empty;
        }

        internal void GameOver(object o, CaughtPlayerEventArgs args)
        {
            _finishGameLabel.color = args.color;
            _finishGameLabel.text = $"Вы проиграли. Вас убил кубик такого цвета.";
        }

    }
}
