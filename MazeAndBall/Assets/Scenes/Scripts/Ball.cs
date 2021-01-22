using UnityEngine;


namespace MazeAndBall
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _speed = 3.0f;
        [SerializeField] private int _lives = 3;
        private Rigidbody _rigidbody;
        private Vector3 _direction;
<<<<<<< Updated upstream
=======
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
>>>>>>> Stashed changes

        private void Start()
        {
            _direction = new Vector3();
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Roll()
        {
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            _rigidbody.AddForce(_direction * _speed);
        }
    }
}