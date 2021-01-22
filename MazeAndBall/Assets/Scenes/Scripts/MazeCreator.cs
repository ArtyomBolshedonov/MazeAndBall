<<<<<<< Updated upstream
﻿using UnityEngine;
=======
﻿using System;
using UnityEngine;
using static UnityEngine.Debug;
>>>>>>> Stashed changes


namespace MazeAndBall
{
    public class MazeCreator : MonoBehaviour
    {
        [SerializeField] private GameObject Wall = null;
        private MapGenerator map;

        private void Awake()
        {
<<<<<<< Updated upstream
=======
            GenerateMap();
            GenerateBonus();
        }

        private void GenerateMap()
        {
            if(Wall == null)
            {
                throw new Exception("Не добавлен префаб стены для генерации лабиринта.");
            }
>>>>>>> Stashed changes
            map = new MapGenerator(21, 21);
            map.ClearMap(ref map.map);
            map.RemoveWall(ref map.map);

            for (int i = 0; i < map.map.GetLength(0); i++)
            {
                for (int j = 0; j < map.map.GetLength(1); j++)
                {
                    if (map.map[i, j].Value == -1) Instantiate(Wall, new Vector3((float)(i * 1), 0, (float)(j * 1)), Quaternion.identity);
                }
            }
<<<<<<< Updated upstream
=======
            Log($"Стен сгенерировано: {wallCount}");
        }

        private void GenerateBonus()
        {
            if (GoodBonus == null)
            {
                throw new Exception("Не добавлен префаб хорошего бонуса.");
            }
            for (int i = 0; i < bonusCount/2; i++)
            {
                var rand = UnityEngine.Random.Range(0, map.corridors.Count);
                Instantiate(GoodBonus, new Vector3(map.corridors[rand].Col, 0,
                    map.corridors[rand].Row), Quaternion.identity);
                map.corridors.Remove(map.corridors[rand]);
                goodBonusCount++;
            }
            if (BadBonus == null)
            {
                throw new Exception("Не добавлен префаб плохого бонуса.");
            }
            Log($"Хороших бонусов сгенерировано: {goodBonusCount}");
            for (int i = bonusCount / 2; i < bonusCount; i++)
            {
                var rand = UnityEngine.Random.Range(0, map.corridors.Count);
                Instantiate(BadBonus, new Vector3(map.corridors[rand].Col, 0,
                    map.corridors[rand].Row), Quaternion.identity);
                map.corridors.Remove(map.corridors[rand]);
                badBonusCount++;
            }
            Log($"Плохих бонусов сгенерировано: {badBonusCount}");
>>>>>>> Stashed changes
        }
    }
}