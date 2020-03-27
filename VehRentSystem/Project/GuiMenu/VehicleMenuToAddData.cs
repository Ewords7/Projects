using les9_game.GuiMenu;
using System;
using System.Collections.Generic;

namespace Project.GuiMenu
{
    class VehicleMenuToAddData
    {
        private TextBlock textBlock;
        public VehicleMenuToAddData()
        {
            textBlock = new TextBlock(10, 5, 100, new List<string> { "Pasirinkite ka norite ivesti i sistema", "",
                "Automobiliai [1]", "Motociklai [2]", "Dviraciai [3]", "Klientai [4]", "", "Grizti i pagrindini menu [Backspace]",
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
