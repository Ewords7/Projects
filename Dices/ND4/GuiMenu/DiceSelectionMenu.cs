using les9_game.GuiMenu;
using ND4.Game;
using System;
using System.Collections.Generic;

namespace ND4.GuiMenu
{
    class DiceSelectionMenu : Window
    {
        public int diceAmount { get; set; } = 1;
        private TextBlock titleTextBlock;

        public DiceSelectionMenu() : base(0, 0, 120, 30, '%')
        {
            // Title parametrai
            titleTextBlock = new TextBlock(10, 5, 100, new List<string> { "Pasirink norima kauliuku skaiciu",
                "Nori daugiau kauliuku? Spausk rodykle i virsu", "Nori maziau kauliuku? Spausk rodykle i apacia" });
        }

        // Didinamas kauliuku kiekis
        public int MoreDices()
        {
            return diceAmount += 1;
        }

        // Mazinamas kauliuku kiekis
        public int LessDices()
        {
            return diceAmount == 1 ? diceAmount : diceAmount -= 1;
        }

        // Kauliuko pasirinkimo atvaizdavimas
        public void DiceSelection()
        {
            Console.SetCursorPosition(50, 10);
            Console.WriteLine($"Kauliuku kiekis: {diceAmount}");
        }

        // Kauliuko pasirinkimo lango atvaizdavimas
        public override void Render()
        {
            base.Render();
            titleTextBlock.Render();
            DiceSelection();
            Console.SetCursorPosition(0, 0);
        }
    }
}
