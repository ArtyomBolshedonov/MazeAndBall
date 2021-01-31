using System;
using UnityEngine;
using static UnityEngine.Random;


namespace MazeAndBall
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation
    {
        private float _lengthFly;
        private float _speedRotation;
        private float bonusTime = 20.0f;

        public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };

        public delegate void CameraShaking(object value);
        private event CameraShaking _shake;
        public event CameraShaking Shake
        {
            add { _shake += value; }
            remove { _shake -= value; }
        }

        private void Awake()
        {
            _lengthFly = Range(1.0f, 3.0f);
            _speedRotation = Range(10.0f, 50.0f);
        }

        protected override void Interaction()
        {
            var player = FindObjectOfType<MyBall>();
            var rb = player.GetComponent<Rigidbody>();
            rb.AddForce(-rb.velocity * 10, ForceMode.Impulse);
            player.Lives--;
            player.Decelerate(bonusTime);
            _shake?.Invoke(this);
            if (player.Lives == 0)
            {
                OnCaughtPlayerChange.Invoke(gameObject.name, _color);
            }
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Fly();
            Rotate();
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
