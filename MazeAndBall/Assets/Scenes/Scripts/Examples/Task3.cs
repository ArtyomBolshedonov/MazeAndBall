using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace MazeAndBall
{
    internal sealed class Task3
    {
        internal void DoTask()
        {
            List<int> list = new List<int>();
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            list.Add(6);
            list.Add(3);
            list.Add(2);
            list.Add(6);
            list.Add(54);
            list.Add(7);
            list.Add(22);
            list.Add(2);
            list.Add(6);
            list.Add(54);
            list.Sort();

            Debug.Log("Задание 3. Дана коллекция List<T>. " +
                "Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции. Результат:");

            foreach (int el in list)
            {
                if (dictionary.ContainsKey(el) == true) dictionary[el]++;
                if (dictionary.ContainsKey(el) == false) dictionary.Add(el, 1);
            }

            foreach (var el in dictionary) Debug.Log("Значение: " + el.Key + " встречается " + el.Value + " раз");

            Debug.Log("Используя Linq. Результат:");

            foreach (var el in list.Distinct())
            {
                Debug.Log("Значение: " + el + " встречается " + list.Where(x => x == el).Count() + " раз");
            }
        }
    }
}
