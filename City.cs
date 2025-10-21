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
            
            for (int i = 8; i < 101; i++)
            {
                Console.SetCursorPosition(i, 0); //det är för City
                Console.Write("=");
                Console.SetCursorPosition(i, 24); // Det är för City
                Console.Write("=");

                Console.SetCursorPosition(i, 35); // Det är för statusfältet
                Console.Write("=");

                Console.SetCursorPosition(i, 40); // Det är för news feed
                Console.Write("=");
            }


            for (int i = 1; i < 24; i++)
            {
                Console.SetCursorPosition(0, i); //det är för City
                Console.Write("X");
                Console.SetCursorPosition(100, i); // Det är för City
                Console.Write("X");
            }
            


            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, 25 + i); // Det är för prison
                Console.Write("X");
                Console.SetCursorPosition(15, 25 + i); // Det är för prison
                Console.Write("X");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 24);
            Console.Write("# prison");
            Console.SetCursorPosition(0, 0);
            Console.Write("# City");

            Console.SetCursorPosition(0, 35);
            Console.Write("# Status");

            Console.SetCursorPosition(0, 40);
            Console.Write("# News Feed");
            Console.ResetColor();
            Console.SetCursorPosition(6, 0);
            Console.Write("==");
        }
    }
}
