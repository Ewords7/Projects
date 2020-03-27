using ND4.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace les9_game.GuiMenu
{
    class Button : GuiObject
    {
        private bool isActive = false;
        private Frame activeFrame;        
        private Frame notActiveFrame;
        protected TextLine Label { get; set; }
        
        public Button(int x, int y, int width, int height, string buttonText) : base(x, y, width, height)
        {
            activeFrame = new Frame(x, y, width, height, '#');
            notActiveFrame = new Frame(x, y, width, height, '+');
            Label = new TextLine(x + 1, y + 1 + ((height - 2 ) / 2), width - 2, buttonText);
        }
        
        // Aktyvuojamas mygtukas
        public void SetActive()
        {
            isActive = true;
        }

        // Disaktyvuojamas mygtukas
        public void DisActive()
        {
            isActive = false;
        }

        // Aktyvaus/neaktyvaus mygtuko atvaizdavimas 
        public override void Render()
        {
            if (isActive)
            {
                activeFrame.Render();
            }
            else
            {
                notActiveFrame.Render();
            }
            Label.Render();
        }
    }
}
