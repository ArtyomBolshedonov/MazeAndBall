using UnityEngine;
using UnityEngine.UI;


namespace MazeAndBall
{
    public class Reference
    {
        private MyBall _myBall;
        private Camera _mainCamera;
        private GameObject _bonus;
        private GameObject _gameOver;
        private GameObject _winGame;
        private Button _restartButton;
        private Canvas _canvas;

        public MyBall MyBall
        {
            get
            {
                if (_myBall == null)
                {
                    var gameObject = Resources.Load<MyBall>("Ball");
                    _myBall = Object.Instantiate(gameObject);
                }

                return _myBall;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }

        public GameObject Bonus
        {
            get
            {
                if (_bonus == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Bonus");
                    _bonus = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _bonus;
            }
        }

        public GameObject GameOver
        {
            get
            {
                if (_gameOver == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/GameOver");
                    _gameOver = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _gameOver;
            }
        }

        public GameObject Win
        {
            get
            {
                if (_winGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/WinGame");
                    _winGame = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _winGame;
            }
        }

        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _restartButton;
            }
        }
    }
}