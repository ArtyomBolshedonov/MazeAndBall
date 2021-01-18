using UnityEngine;


namespace MazeAndBall
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation
    {
        private MyBall player;
        private Rigidbody rb;
        private float _lengthFlay;
        private float _speedRotation;
        private float bonusTime = 20.0f;

        private void Awake()
        {
            player = FindObjectOfType<MyBall>();
            rb = player.GetComponent<Rigidbody>();
            _lengthFlay = Random.Range(1.0f, 3.0f);
            _speedRotation = Random.Range(30.0f, 50.0f);
        }

        protected override void Interaction()
        {
            rb.AddForce(-rb.velocity*10, ForceMode.Impulse);
            player.Decelerate(bonusTime);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}
