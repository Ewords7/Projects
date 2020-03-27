using les9_game.GuiMenu;
using ND4.Game;
using System;
using System.Collections.Generic;

namespace ND4.GuiMenu
{
    class GameEndMenu : Window
    {
        private TextBlock titleTextBlock;
        public int diceAmount { get; set; } = 1;

        public GameEndMenu() : base(0, 0, 120, 30, '%')
        {
            // Title parametrai
            titleTextBlock = new TextBlock(10, 5, 100, new List<string> { "Nori pakartoti ka tik ivykusi zaidima is naujo? Spausk - R", "Nori grizti i meniu? Spausk - M",
                "Nori uzdaryti zaidima? Spausk - Q" });
        }

        // Grizimas i meniu
        public void BackToMenu()
        {  
            GuiController controller = new GuiController();
            controller.ShowMenu();
        }

        // Isejimas is zaidimo
        public void QuitGame()
        {
            Console.Clear();
            Environment.Exit(0);
        }

        // Zaidimo pabaigos meniu atvaizdavimas
        public override void Render()
        {
            base.Render();
            titleTextBlock.Render();
            Console.SetCursorPosition(0, 0);
        }
    }
}
