using System;
using UnityEngine;


namespace MazeAndBall
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation
    {
        private MyBall player;
        private Rigidbody rb;
        private float _lengthFly;
        private float _speedRotation;
        private float bonusTime = 20.0f;

        private event EventHandler<CaughtPlayerEventArgs> _caughtPlayer;
        internal event EventHandler<CaughtPlayerEventArgs> CaughtPlayer
        {
            add { _caughtPlayer += value; }
            remove { _caughtPlayer -= value; }
        }

        public delegate void CameraShaking(object value);
        private event CameraShaking _shake;
        public event CameraShaking Shake
        {
            add { _shake += value; }
            remove { _shake -= value; }
        }

        private void Awake()
        {
            player = FindObjectOfType<MyBall>();
            rb = player.GetComponent<Rigidbody>();
            _lengthFly = UnityEngine.Random.Range(1.0f, 3.0f);
            _speedRotation = UnityEngine.Random.Range(30.0f, 50.0f);
        }

        protected override void Interaction()
        {
            rb.AddForce(-rb.velocity*10, ForceMode.Impulse);
            player.Lives--;
            player.Decelerate(bonusTime);
            _shake?.Invoke(this);
            if (player.Lives == 0)
            {
                _caughtPlayer?.Invoke(this, new CaughtPlayerEventArgs(_color));
            }
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}
