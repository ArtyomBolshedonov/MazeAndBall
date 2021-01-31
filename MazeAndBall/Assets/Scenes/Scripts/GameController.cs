using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace MazeAndBall
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        public enum PlayerType
        {
            None = 0,
            Ball = 1,
            Cube = 2
        }

        [SerializeField] private int mapLengthX = 0;
        [SerializeField] private int mapLengthY = 0;
        [SerializeField] private int bonusCount = 0;
        [SerializeField] private PlayerType playerType = PlayerType.Ball;

        private MazeCreator _mazeCreator;
        private Reference _reference;
        private InputController _inputController;
        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayWinGame _displayWinGame;
        private DisplayBonuses _displayBonuses;
        private Camera _camera;
        private CameraEffects _effect;

        private int _countBonuses;
        private int _goodBonusesCount;

        private void Awake()
        {
            _mazeCreator = new MazeCreator();
            _mazeCreator.GenerateMap(mapLengthX, mapLengthY);
            _mazeCreator.GenerateBonus(bonusCount);
            _interactiveObject = new ListExecuteObject();
            _reference = new Reference();
            MyBall _player = null;

            if(playerType == PlayerType.Ball)
            {
                _player = _reference.MyBall;
            }

            _camera = _reference.MainCamera;

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(_player);
                _interactiveObject.AddExecuteObject(_inputController);
            }

            _displayEndGame = new DisplayEndGame(_reference.GameOver);
            _displayWinGame = new DisplayWinGame(_reference.Win);
            _displayBonuses = new DisplayBonuses(_reference.Bonus);
            _effect = new CameraEffects(_camera);
            _interactiveObject.AddExecuteObject(_inputController);

            foreach (var o in _interactiveObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                    badBonus.Shake += _effect.CameraShaking;
                }

                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonuse;
                    _goodBonusesCount++;
                }
            }
            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.Bonus.SetActive(true);
            _reference.RestartButton.gameObject.SetActive(false);
            _reference.Win.SetActive(false);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }

        private void CaughtPlayer(string value, Color args)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void AddBonuse(int value)
        {
            _countBonuses += value;
            _displayBonuses.Display(_countBonuses);
            if(_countBonuses == _goodBonusesCount)
            {
                _reference.Bonus.SetActive(false);
                _reference.Win.SetActive(true);
                _displayWinGame.WinGame(_countBonuses);
                _reference.RestartButton.gameObject.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObject)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                    badBonus.Shake -= _effect.CameraShaking;
                }

                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonuse;
                }
            }
        }
    }
}
