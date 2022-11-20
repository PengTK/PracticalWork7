using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork7
{
    internal class Arrow
    {
        public int min;
        public int max;
        private int position;
        private ConsoleKeyInfo key;

        public Arrow(int Min, int Max)
        {
            min = Min;
            max = Max;
        }

        public int CheckPos()
        {
            position = min;
            while(true)
            {
                Console.SetCursorPosition(0, position);
                Console.Write("->");
                Console.SetCursorPosition(0,0);
                key = Console.ReadKey();
                Console.SetCursorPosition(0, position);
                Console.Write("  ");
                if (key.Key == ConsoleKey.UpArrow && position > min)
                {
                    position--;
                }
                if (key.Key == ConsoleKey.DownArrow && position < max)
                {
                    position++;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    return position;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    return 0;
                }
            }
        }
    }
}
