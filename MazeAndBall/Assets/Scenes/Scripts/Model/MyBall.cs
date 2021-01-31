using UnityEngine;
using System.Collections;


namespace MazeAndBall
{
    public class MyBall : BallBase
    {
        [SerializeField] private float _speed = 3.0f;
        [SerializeField] private int _lives = 3;

        private Rigidbody _rigidbody;

        private static float normalSpeed;

        public int Lives
        {
            get
            {
                return _lives;
            }
            set
            {
                _lives = value;
            }
        }

        private void Awake()
        {
            normalSpeed = _speed;
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void Roll(float x, float y, float z)
        {
            _rigidbody.AddForce(new Vector3(x, y, z) * _speed);
        }

        public void Accelerate(float bonusTime)
        {
            _speed *= 2;
            StartCoroutine(BonusTime(bonusTime));
        }

        public void Decelerate(float bonusTime)
        {
            _speed /= 2;
            StartCoroutine(BonusTime(bonusTime));
        }

        IEnumerator BonusTime(float bonusTime)
        {
            yield return new WaitForSeconds(bonusTime);
            _speed = normalSpeed;
        }
    }
}