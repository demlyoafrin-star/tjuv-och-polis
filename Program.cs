using System.Security.Cryptography.X509Certificates;

namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            City.DrawCity();



            List<Person> people = new List<Person>();
            people.Add(new Police("P", 10, 10));
            people.Add(new Thief("T", 15, 10));
            people.Add(new Citizen("M", 10, 15));


            foreach (var person in people)
            {
                Console.SetCursorPosition(person.X, person.Y);
                Console.WriteLine(person.Name);
            }

            Console.ReadKey();
            //Console.SetCursorPosition(10, 10);
            //Console.WriteLine("T");
            //Console.SetCursorPosition(20, 10);
            //Console.WriteLine("P");
            //Console.SetCursorPosition(30, 10);
            //Console.WriteLine("M");
            //ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            //Console.ReadKey();




        }
    }
}
