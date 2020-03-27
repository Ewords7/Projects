using System;
using System.Collections.Generic;

namespace les9_game.GuiMenu
{
    class MainMenu
    {
        private TextBlock titleTextBlock;

        public MainMenu()
        {
            // Title parametrai
            titleTextBlock = new TextBlock(10, 5, 100, new List<string> { "Transporto nuoma", "", "Administravimas [1]",
                "Transporto/klientu informacija [2]", "Paieska [3]", "", "Uzdaryti programa [Esc]" });
        }

        // Meniu atvaizdavimas
        public void Render()
        {
            titleTextBlock.Render();
            Console.SetCursorPosition(0, 0);
        }
    }
}
