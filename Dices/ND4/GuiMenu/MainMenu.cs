using ND4.Game;
using System;
using System.Collections.Generic;

namespace les9_game.GuiMenu
{
    class MainMenu : Window
    {
        private TextBlock titleTextBlock;

        public MainMenu() : base(0, 0, 120, 30, '%')
        {
            // Title parametrai
            titleTextBlock = new TextBlock(10, 5, 100, new List<string> { "Zaidimas", "Noredami pradeti zaidima spauskite klavisa - P",
                "Noredami uzdaryti zaidima spauskite klavisa - Q" });
        }

        // Pagrindinio meniu lango atvaizdavimas
        public override void Render()
        {
            base.Render();
            titleTextBlock.Render();
            Console.SetCursorPosition(0, 0);
        }
    }
}
