using UnityEngine;


namespace MazeAndBall
{
    public sealed class InputController : IExecute
    {
        private readonly MyBall _player;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly PhotoController _photoController;
        private readonly KeyCode _saveData = KeyCode.C;
        private readonly KeyCode _loadData = KeyCode.V;
        private readonly KeyCode _screenShot = KeyCode.F;

        public InputController(MyBall player)
        {
            _player = player;
            _saveDataRepository = new SaveDataRepository();
            _photoController = new PhotoController();
        }

        public void Execute()
        {
            _player.Roll(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            if (Input.GetKeyDown(_saveData))
            {
                _saveDataRepository.Save(_player.gameObject);
            }
            if (Input.GetKeyDown(_loadData))
            {
                _saveDataRepository.Load(_player.gameObject);
            }
            if (Input.GetKeyDown(_screenShot))
            {
                _photoController.FirstMethod();
            }
        }
    }
}
