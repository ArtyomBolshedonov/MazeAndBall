using System;
using UnityEngine;
using static UnityEngine.Random;


namespace MazeAndBall
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        [SerializeField] private int Point = 1;

        private Material _material;

        private float _lengthFly;
        private float bonusTime = 10.0f;
        
        public event Action<int> OnPointChange = delegate (int i) { };
        
        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Range(1.0f, 2.0f);
        }

        protected override void Interaction()
        {
            var player = FindObjectOfType<MyBall>();
            player.Accelerate(bonusTime);
            OnPointChange.Invoke(Point);
        }

        public override void Execute()
        {
            if (!IsInteractable) { return; }
            Fly();
            Flick();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}
