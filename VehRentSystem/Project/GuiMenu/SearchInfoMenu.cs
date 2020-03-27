using les9_game.GuiMenu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.GuiMenu
{
    class SearchInfoMenu
    {
        private TextBlock textBlock;
        public SearchInfoMenu()
        {
            // Title parametrai
            textBlock = new TextBlock(10, 5, 100, new List<string> { "Isnuomotu transporto priemoniu paieska pagal", "",
                "Automobilio numeri [1]", "Motociklo numeri [2]", "Dviracio ID [3]", "Klientu asmens koda [4]", "",
                "Kliento asmens kodo paieska pagal", "", "Kliento pavarde [5]", "", "Grizti i pagrindini menu [Backspace]",
                "Uzadaryti programa [Esc]" });

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
