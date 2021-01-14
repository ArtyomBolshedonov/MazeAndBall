using UnityEngine;


namespace MazeAndBall
{
    public class MazeCreator : MonoBehaviour
    {
        [SerializeField] private GameObject Wall = null;
        private MapGenerator map;

        private void Start()
        {
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
        }
    }
}