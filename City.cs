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
                Console.SetCursorPosition(i, 24); // Det är för City samt statusfältet
                Console.Write("=");

                Console.SetCursorPosition(i, 28); // Det är för news feed
                Console.Write("=");

            }

            //for city
            for (int i = 1; i < 24; i++)
            {
                Console.SetCursorPosition(0, i); 
                Console.Write("X");
                Console.SetCursorPosition(100, i); 
                Console.Write("X");
            }
            

            //for prison
            for (int i = 1; i < 10; i++)
            {
                
                Console.SetCursorPosition(112, 0 + i);
                Console.Write("X");
            }


            // for polis station
            for (int i = 1; i < 4; i++)
            {
                Console.SetCursorPosition(128, 4 + i);
                Console.Write("X");
            }
            for (int i = 114; i < 129; i++)
            {
                Console.SetCursorPosition(i, 4);
                Console.Write("=");
                Console.SetCursorPosition(i, 8);
                Console.Write("=");
            }




            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition(0, 0);
            Console.Write("# City");

           
            Console.SetCursorPosition(101, 0);
            Console.Write("# prison");
            Console.SetCursorPosition(114, 3);
            Console.Write("Police station");
            


            Console.SetCursorPosition(0, 24);
            Console.Write("# Status");
            Console.SetCursorPosition(0, 28);
            Console.Write("# News Feed");
            Console.ResetColor();

            //rest of all the corners
            Console.SetCursorPosition(6, 0); //Rest of city
            Console.Write("==");
            Console.SetCursorPosition(108, 0); // prison
            Console.Write("=====");
            Console.SetCursorPosition(101, 10); // prison
            Console.Write("============");
        }
    }
}
