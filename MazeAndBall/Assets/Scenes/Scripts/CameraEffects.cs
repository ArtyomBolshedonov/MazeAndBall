using UnityEngine;


namespace MazeAndBall
{
    public sealed class CameraEffects
    {
        private Camera camera;

        public CameraEffects(Camera Camera)
        {
            camera = Camera;
        }

        internal void CameraShaking(object o)
        {
            camera.GetComponent<Animation>().Play();
        }
    }
}
