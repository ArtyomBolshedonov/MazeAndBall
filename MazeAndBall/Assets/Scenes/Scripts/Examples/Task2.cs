using System.Text.RegularExpressions;
using UnityEngine;


namespace MazeAndBall
{
    internal sealed class Task2
    {
        internal void DoTask()
        {
            string s = "Это тестовый класс для выполнения д.з. №5.2! wtf??";
            Debug.Log(s);
            int i = s.CharCount();
            Debug.Log("Количество символов в этой строке:" + i);
        }
    }
    internal static class StringExtension
    {
        internal static int CharCount(this string str)
        {
            //Для всех символов включая пробелы (ведь это тоже символ).
            //return str.Length;

            //Для всех символов кроме пробелов.
            return Regex.Matches(str, @"\S").Count;
        }
    }
}
