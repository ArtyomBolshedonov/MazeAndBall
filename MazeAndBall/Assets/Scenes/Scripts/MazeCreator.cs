using UnityEngine;
<<<<<<< Updated upstream
=======
using static UnityEngine.Debug;
>>>>>>> Stashed changes


namespace MazeAndBall
{
    internal class MazeCreator
    {
        private GameObject Wall;
        private GameObject GoodBonus;
        private GameObject BadBonus;
        private MapGenerator map;

<<<<<<< Updated upstream
        private void Start()
        {
            map = new MapGenerator(21, 21);
=======
        internal MazeCreator()
        {
            Wall = (GameObject)Resources.Load("Wall");
            GoodBonus = (GameObject)Resources.Load("GoodBonus");
            BadBonus = (GameObject)Resources.Load("BadBonus");
        }

        internal void GenerateMap(int mapLengthX, int mapLengthY)
        {
            int wallCount = 0;
            if (Wall == null)
            {
                throw new System.Exception("Нет модели стены в папке ресурсов для генерации лабиринта.");
            }
            map = new MapGenerator(mapLengthX, mapLengthY);
>>>>>>> Stashed changes
            map.ClearMap(ref map.map);
            map.RemoveWall(ref map.map);

            for (int i = 0; i < map.map.GetLength(0); i++)
            {
                for (int j = 0; j < map.map.GetLength(1); j++)
                {
                    if (map.map[i, j].Value == -1)
                    {
                        Object.Instantiate(Wall, new Vector3((float)(i * 1), 0, (float)(j * 1)), Quaternion.identity);
                        wallCount++;
                    }
                }
            }
<<<<<<< Updated upstream
=======
            Log($"Стен сгенерировано: {wallCount}");
        }

        internal void GenerateBonus(int bonusCount)
        {
            int goodBonusCount = 0;
            int badBonusCount = 0;
            if (GoodBonus == null)
            {
                throw new System.Exception("Нет модели хорошего бонуса в папке ресурсов.");
            }
            for (int i = 0; i < bonusCount / 2; i++)
            {
                var rand = Random.Range(2, map.corridors.Count);
                Object.Instantiate(GoodBonus, new Vector3(map.corridors[rand].Col, 0,
                    map.corridors[rand].Row), Quaternion.identity);
                map.corridors.Remove(map.corridors[rand]);
                goodBonusCount++;
            }
            if (BadBonus == null)
            {
                throw new System.Exception("Нет модели плохого бонуса в папке ресурсов.");
            }
            Log($"Хороших бонусов сгенерировано: {goodBonusCount}");
            for (int i = bonusCount / 2; i < bonusCount; i++)
            {
                var rand = Random.Range(2, map.corridors.Count);
                Object.Instantiate(BadBonus, new Vector3(map.corridors[rand].Col, 0,
                    map.corridors[rand].Row), Quaternion.identity);
                map.corridors.Remove(map.corridors[rand]);
                badBonusCount++;
            }
            Log($"Плохих бонусов сгенерировано: {badBonusCount}");
>>>>>>> Stashed changes
        }
    }
}