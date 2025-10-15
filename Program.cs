using System.Security.Cryptography.X509Certificates;

namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            City.DrawCity();






            Console.SetCursorPosition(10, 10);
            Console.WriteLine("T");
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("P");
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("M");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            Console.ReadKey();




        }
    }
}
