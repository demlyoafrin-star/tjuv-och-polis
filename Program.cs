using System.Security.Cryptography.X509Certificates;

namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            for (int i = 8; i < 65; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
                Console.SetCursorPosition(i,24);
                Console.Write("=");
            }

            for (int i = 0; i < 25; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("X");
                Console.SetCursorPosition(65, i);
                Console.Write("X");
            }

            Console.SetCursorPosition(1, 24);
            Console.Write(" prison");
            Console.SetCursorPosition(3, 0);
            Console.Write("City");
            ConsoleKeyInfo key = Console.ReadKey(true);
            Console.ReadKey();





        }
    }
}
