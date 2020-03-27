using les9_game.GuiMenu;
using System;

namespace ND4
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            GuiController menu = new GuiController();
            menu.ShowMenu();
        }
    }
}