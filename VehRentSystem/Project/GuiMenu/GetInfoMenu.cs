using les9_game.GuiMenu;
using System;
using System.Collections.Generic;

namespace Project.GuiMenu
{
    class GetInfoMenu
    {
        private TextBlock textBlock;
        public GetInfoMenu()
        {
            // Title  parametrai
            textBlock = new TextBlock(10, 1, 100, new List<string> { "Turimo tansporto ir klientu sarasai", "", "Automobiliai [A]",
                "Motociklai [B]", "Dviraciai [C]", "Klientai [D]", "", "Galimas isnuomoti transportas", "", "Automobiliai [E]",
                "Motociklai [F]", "Dviraciai [G]", "", "Isnuomotas transportas", "", "Automobiliai [H]", "Motociklai [I]", "Dviraciai [J]",
                "", "Transporto eksplotacijos dokumentu galiojimo laikas", "", "Automobiliai [K]", "Motociklai [L]", "",
                "Grizti i pagrindini menu [Backspace]", "Uzdaryti programa [Esc]"});
        }

        // Menu atvaizdavimas
        public void Render()
        {
            Console.Clear();
            Console.CursorVisible = false;
            textBlock.Render();
            Console.SetCursorPosition(0, 0);
        }
    }
}
