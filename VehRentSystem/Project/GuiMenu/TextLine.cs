using System;

namespace les9_game.GuiMenu
{
    class TextLine : GuiObject
    {
        protected string Label { get; }

        public TextLine(int x, int y, int width, string data) : base(x, y, width, 0)
        {
            Label = data;
        }

        // Teksto linijos atvaizdavimas
        public override void Render()
        {
            Console.SetCursorPosition(X, Y);
            if (Width > Label.Length)
            {
                int offset = (Width - Label.Length) / 2;
                for (int i = 0; i < offset; i++)
                {
                    Console.Write(' ');
                }
            }
            Console.Write(Label);
        }
    }
}
