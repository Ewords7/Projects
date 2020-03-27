using les9_game.GuiMenu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.GuiMenu
{
    class RentMenu
    {
        private TextBlock textBlock;
        public RentMenu()
        {
            // Title parametrai
            textBlock = new TextBlock(10, 5, 100, new List<string> { "Pasirinkite kokia transporto priemone norite isnuomoti", "",
                "Automobili [1]", "Motocikla [2]", "Dvirati [3]", "", "Grazino isnuomota", "", "Automobili [4]", "Motocikla [5]",
                "Dvirati [6]", "", "Grizti i pagrindini menu [Backspace]", "Uzadaryti programa [Esc]" });

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
