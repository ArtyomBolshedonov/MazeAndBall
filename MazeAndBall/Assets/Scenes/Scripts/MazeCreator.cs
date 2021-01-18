using UnityEngine;
using static UnityEngine.Debug;


namespace MazeAndBall
{
    public class MazeCreator : MonoBehaviour
    {
        [SerializeField] private GameObject Wall = null;
        [SerializeField] private GameObject GoodBonus = null;
        [SerializeField] private GameObject BadBonus = null;
        [SerializeField] private int bonusCount = 0;
        private int wallCount;
        private int goodBonusCount;
        private int badBonusCount;
        private MapGenerator map;

        private void Start()
        {
            GenerateMap();
            GenerateBonus();
        }

        private void GenerateMap()
        {
            map = new MapGenerator(21, 21);
            map.ClearMap(ref map.map);
            map.RemoveWall(ref map.map);

            for (int i = 0; i < map.map.GetLength(0); i++)
            {
                for (int j = 0; j < map.map.GetLength(1); j++)
                {
                    if (map.map[i, j].Value == -1)
                    {
                        Instantiate(Wall, new Vector3((float)(i * 1), 0, (float)(j * 1)), Quaternion.identity);
                        wallCount++;
                    }
                }
            }
            Log($"Стен сгенерировано: {wallCount}");
        }

        private void GenerateBonus()
        {
            for (int i = 0; i < bonusCount/2; i++)
            {
                var rand = Random.Range(0, map.corridors.Count);
                Instantiate(GoodBonus, new Vector3(map.corridors[rand].Col, 0,
                    map.corridors[rand].Row), Quaternion.identity);
                goodBonusCount++;
            }
            Log($"Хороших бонусов сгенерировано: {goodBonusCount}");
            for (int i = bonusCount / 2; i < bonusCount; i++)
            {
                var rand = Random.Range(0, map.corridors.Count);
                Instantiate(BadBonus, new Vector3(map.corridors[rand].Col, 0,
                    map.corridors[rand].Row), Quaternion.identity);
                badBonusCount++;
            }
            Log($"Плохих бонусов сгенерировано: {badBonusCount}");
        }
    }
}