using System;
using UnityEngine;


namespace MazeAndBall
{
    class CaughtPlayerEventArgs : EventArgs
    {
        public Color color { get; }
        // Можем дописать сколько угодно свойств
        public CaughtPlayerEventArgs(Color Color)
        {
            color = Color;
        }
    }
}
