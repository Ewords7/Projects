using System;

namespace les9_game.GuiMenu
{
    abstract class GuiObject
    {
        protected int X { get; set; }
        protected int Y { get; set; }
        protected int Height { get; set; }
        protected int Width { get; set; }
        public GuiObject(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public abstract void Render();
    }
}
