using les9_game.GuiMenu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.GuiMenu
{
    class DataEditingMenu
    {
        private TextBlock textBlock;
        public DataEditingMenu()
        {
            // Title parametrai
            textBlock = new TextBlock(10, 5, 100, new List<string> { "Pasirinkite ka norite redaguoti", "",
                "Automobilio duomenys [1]", "Motociklo duomenys [2]", "Dviraciu duomenys [3]", "Klientu duomenys [4]", "",
                "Automobilio dokumentu duomenys [5]", "Motociklo dokumentu duomenys [6]", "", "Grizti i pagrindini menu [Backspace]",
                "Uzdaryti programa [Esc]" });

        }

        // Meniu atvaizdavimas
        public void Render()
        {
            Console.Clear();
            Console.CursorVisible = false;
            textBlock.Render();
            Console.SetCursorPosition(0, 0);
        }
    }
}
