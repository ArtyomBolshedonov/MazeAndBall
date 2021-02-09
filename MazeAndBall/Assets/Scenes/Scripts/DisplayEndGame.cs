using System;
using UnityEngine;
using UnityEngine.UI;


namespace MazeAndBall
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;

        public DisplayEndGame(GameObject gameOver)
        {
            _finishGameLabel = gameOver.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
        }

        internal void GameOver(string name, Color color)
        {
            _finishGameLabel.color = color;
            _finishGameLabel.text = "Вы проиграли. Вас убил:" + name + "такого цвета.";
        }
    }
}
