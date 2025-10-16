using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class City
    {
        public static void DrawCity()
        {
           
            for (int i = 8; i < 100; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
                Console.SetCursorPosition(i, 24);
                Console.Write("=");
            }
            for (int i = 0; i < 25; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("X");
                Console.SetCursorPosition(100, i);
                Console.Write("X");
            }
            Console.SetCursorPosition(1, 24);
            Console.Write(" prison");
            Console.SetCursorPosition(3, 0);
            Console.Write("City");

        }
    }
}
