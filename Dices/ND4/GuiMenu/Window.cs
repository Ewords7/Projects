using ND4.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace les9_game.GuiMenu
{
    class Window : GuiObject
    {
        private Frame border;
        public Window(int x, int y, int width, int height, char borderChar) : base(x, y, width, height)
        {
            border = new Frame(x, y, width, height, borderChar);
        }

        // Lango atvaizdavimas
        public override void Render()
        {
            border.Render();
        }
    }
}
