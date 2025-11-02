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
                Console.SetCursorPosition(i, 0); Console.Write("="); //det är för City
                Console.SetCursorPosition(i, 24); Console.Write("="); // Det är för City samt statusfältet
                Console.SetCursorPosition(i, 28); Console.Write("="); // Det är för news feed
            }
            //for city
            for (int i = 1; i < 24; i++)
            {
                Console.SetCursorPosition(0, i);  Console.Write("X");
                Console.SetCursorPosition(100, i); Console.Write("X");
            }


            //for prison
            for (int i = 1; i < 10; i++)
            {
                Console.SetCursorPosition(112, 0 + i);Console.Write("X");
            }


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 0); Console.Write("# City");
            Console.SetCursorPosition(101, 0); Console.Write("# prison");
            Console.SetCursorPosition(0, 24); Console.Write("# Status");
            Console.SetCursorPosition(0, 28); Console.Write("# News Feed");

            Console.ResetColor();

            //rest of all the corners
            Console.SetCursorPosition(6, 0);Console.Write("=="); //Rest of city

            Console.SetCursorPosition(109, 0); Console.Write("===="); // prison
            Console.SetCursorPosition(101, 10);  Console.Write("============"); // prison
        }
    }
}
