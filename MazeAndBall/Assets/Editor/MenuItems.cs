using UnityEditor;

namespace MazeAndBall
{
    public class MenuItems
    {
        [MenuItem("MazeAndBall/Создание объектов")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "MazeAndBall");
        }
    }
}
