using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class City
    {
        public static void DrawCity()
        {
            int width = 101;
            int height = 24;
            int prisonWidth = 25;
            int prisonHeight = 10;

            for (int i = 8; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
                Console.SetCursorPosition(i, 24);
                Console.Write("=");

                Console.SetCursorPosition(i, 35); // Det är för statusfältet
                Console.Write("=");

                Console.SetCursorPosition(i, 40); // Det är för news feed
                Console.Write("=");
            }


            for (int i = 1; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("X");
                Console.SetCursorPosition(100, i);
                Console.Write("X");
            }
            


            for (int i = 0; i < prisonHeight; i++)
            {
                Console.SetCursorPosition(0, prisonWidth + i);
                Console.Write("X");
                Console.SetCursorPosition(15, prisonWidth + i);
                Console.Write("X");
            }

            Console.SetCursorPosition(0, 24);
            Console.Write("# prison");
            Console.SetCursorPosition(0, 0);
            Console.Write("# City==");

            Console.SetCursorPosition(0, 35);
            Console.Write("# Status");

            Console.SetCursorPosition(0, 40);
            Console.Write("# News Feed");

        }
    }
}
