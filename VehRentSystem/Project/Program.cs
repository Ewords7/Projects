using les9_game.GuiMenu;
using System;

namespace Project
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            GuiController controller = new GuiController();
            controller.ShowMenu();
        }
    }
}
