using System;
using System.Collections.Generic;
using System.Text;

namespace n9
{
    public readonly struct Pixelfood
    {

        private const char PixelCharfood = '@';
        public Pixelfood(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(left: X, top: Y);
            Console.Write(PixelCharfood);

        }

        public void Clear()
        {
            Console.SetCursorPosition(left: X, top: Y);
            Console.Write(' ');
        }

    }
    public readonly struct Pixelgran
    {

        private const char PixelChargran = '#';
        private const char PixelChargranY = '#';
        public Pixelgran(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
        public void DrawX()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(left: X, top: Y);
            Console.Write(PixelChargran);

        }
        public void DrawY()
        {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(left: X, top: Y);
                Console.Write(PixelChargranY);

        }

            public void Clear()
        {
            Console.SetCursorPosition(left: X, top: Y);
            Console.Write(' ');
        }

    }
    public readonly struct Pixel
    {

        private const char PixelChar = '*';
        public Pixel(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(left: X, top: Y);
            Console.Write(PixelChar);

        }

        public void Clear()
        {
            Console.SetCursorPosition(left: X, top: Y);
            Console.Write(' ');
        }

    }

}
