using System;
using UnityEngine;
using UnityEngine.UI;

namespace MazeAndBall
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {

        [SerializeField] private Text _finishGameLabel = null;
        [SerializeField] private Camera _camera = null;
        private CameraEffects _effect;
        private DisplayEndGame _displayEndGame;
        private InteractiveObject[] _interactiveObjects;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            _displayEndGame = new DisplayEndGame(_finishGameLabel);
            _effect = new CameraEffects(_camera);
            for (int i = 0; i < _interactiveObjects.Length; i++)
            {
                if(_interactiveObjects[i] is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;
                    badBonus.Shake += _effect.CameraShaking;
                }
            }
        }

        private void CaughtPlayer(object value, CaughtPlayerEventArgs args)
        {
            Time.timeScale = 0.0f;
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFly fly)
                {
                    fly.Fly();
                }
                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flick();
                }
                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotate();
                }
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < _interactiveObjects.Length; i++)
            {
                if (_interactiveObjects[i] is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer -= CaughtPlayer;
                    badBonus.CaughtPlayer -= _displayEndGame.GameOver;
                    badBonus.Shake -= _effect.CameraShaking;
                }
                Destroy(_interactiveObjects[i].gameObject);
            }
        }
    }
}
