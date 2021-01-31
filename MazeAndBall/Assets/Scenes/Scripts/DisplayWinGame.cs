using System;
using UnityEngine;
using UnityEngine.UI;


namespace MazeAndBall
{
    public sealed class DisplayWinGame
    {
        private Text _winGameLabel;

        public DisplayWinGame(GameObject winGame)
        {
            _winGameLabel = winGame.GetComponentInChildren<Text>();
            _winGameLabel.text = String.Empty;
        }

        internal void WinGame(int value)
        {
            _winGameLabel.text = $"Победа! Вы набрали {value}.";
        }
    }
}