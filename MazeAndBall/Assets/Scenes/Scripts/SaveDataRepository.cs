using System.IO;
using UnityEngine;

namespace MazeAndBall
{
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                //_data = new PlayerPrefsData();
            }
            else
            {
                _data = new JsonData<SavedData>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);

        }

        public void Save(GameObject obj)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var savedData = new SavedData
            {
                Name = obj.name,
                Position = obj.transform.position,
                IsEnabled = obj.activeSelf,
            };

            _data.Save(savedData, Path.Combine(_path, _fileName));

        }
    
        public void Load(GameObject obj)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newObject = _data.Load(file);
            obj.name = newObject.Name;
            obj.transform.position = newObject.Position;
            obj.gameObject.SetActive(newObject.IsEnabled);

            Debug.Log(newObject);
        }
    }
}