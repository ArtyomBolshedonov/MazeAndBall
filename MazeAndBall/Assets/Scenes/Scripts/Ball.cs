using UnityEngine;
using System.Collections;


namespace MazeAndBall
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _speed = 3.0f;
        private Rigidbody _rigidbody;
        private Vector3 _direction;
        private static float normalSpeed;
        private void Start()
        {
            normalSpeed = _speed;
            _direction = new Vector3();
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Roll()
        {
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            _rigidbody.AddForce(_direction * _speed);
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