using les9_game.GuiMenu;
using System;
using System.Collections.Generic;

namespace ND4.GuiMenu
{
    class AdministrationMenu
    {        
        private TextBlock titleTextBlock;
        
        public AdministrationMenu()
        {
            // Title parametrai
            titleTextBlock = new TextBlock(10, 5, 100, new List<string> { "Administravimas", "", "Duomenu ivedimas [1]",
                "Duomenu redagavimas [2]", "Irasu salinimas [3]", "Isnuomoti/grazinti transporto priemone [4]", "",
                "Grizti i pagrindini menu [Backspace]", "Uzdaryti programa [Esc]"});
        }        

        // Meniu atvaizdavimas
        public void Render()
        {
            Console.Clear();
            titleTextBlock.Render();
            Console.SetCursorPosition(0, 0);
        }
    }
}
