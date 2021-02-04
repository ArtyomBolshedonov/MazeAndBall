using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace MazeAndBall
{
    internal sealed class Task4
    {
        private static int CurrentMethod(KeyValuePair<string, int> pair)
        {
            return pair.Value;
        }

        internal void DoTask()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };

            //var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value;});
            
            Debug.Log("Задание 4.а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>. Результат:");

            var d = dict.OrderBy(pair => pair.Value);

            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

            Debug.Log("Задание 4.б. * Развернуть обращение к OrderBy с использованием делегата. Результат:");

            Func<KeyValuePair<string, int>, int> method = CurrentMethod;

            var dd = dict.OrderBy(method);

            foreach (var pair in dd)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
