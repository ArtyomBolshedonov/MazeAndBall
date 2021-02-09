using UnityEngine;


namespace MazeAndBall
{
    public abstract class BallBase : MonoBehaviour
    {
        public abstract void Roll(float x, float y, float z);
    }
}