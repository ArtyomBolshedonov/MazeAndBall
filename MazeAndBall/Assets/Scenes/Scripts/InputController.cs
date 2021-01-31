using UnityEngine;


namespace MazeAndBall
{
    public sealed class InputController : IExecute
    {
        private readonly BallBase _ballBase;

        public InputController(BallBase player)
        {
            _ballBase = player;
        }

        public void Execute()
        {
            _ballBase.Roll(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }
    }
}
