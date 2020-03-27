using les9_game.GuiMenu;
using System;
using System.Collections.Generic;

namespace Project.GuiMenu
{
    class DataDeleteMenu
    {
        private TextBlock titleTextBlock;

        public DataDeleteMenu()
        {
            // Title parametrai
            titleTextBlock = new TextBlock(10, 5, 100, new List<string> { "Pasirinkite is kur salinsite irasus", "", "Automobliliai [1]",
                "Motociklai [2]", "Dviraciai [3]", "Klientai [4]", "", "Grizti i pagrindini menu [Backspace]", "Uzdaryti programa [Esc]"});
        }

        // Meniu atvaizdavimas
        public void Render()
        {
            Console.Clear();
            Console.CursorVisible = false;
            titleTextBlock.Render();
            Console.SetCursorPosition(0, 0);
        }
    }
}
