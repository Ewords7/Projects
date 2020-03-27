using ND4.Game;
using System;

namespace les9_game.GuiMenu
{
    class Frame : GuiObject
    {
        private char renderChar;

        public Frame (int x, int y, int width, int height, char renderChar) : base(x, y, width, height)
        {
            this.renderChar = renderChar;
        }

        // Remelio atvaizdavimas
        public override void Render()
        {
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                if (i == 0 || i == Height - 1)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        Console.Write(renderChar);
                    }
                }
                else
                {
                    Console.Write(renderChar);
                    for (int j = 0; j < Width - 2; j++)
                    {
                        Console.Write(' ');
                    }
                    Console.Write(renderChar);
                }
            }
        }
    }
}
