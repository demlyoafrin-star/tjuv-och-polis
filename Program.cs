using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            City.DrawCity();
            List<Person> people = new List<Person>();
            


            while (true)
            {
              
                Console.ForegroundColor = ConsoleColor.Red;
                //people.Add(new Police("P", Random.Shared.Next(1, 99), Random.Shared.Next(1, 23)));
                people.Add(new Police("P",5, 0, 0));
                people.Add(new Thief("T",10, 0, 0));
                people.Add(new Citizen("M",20, 0, 0));
                

                foreach (var person in people)
                {
                    Console.SetCursorPosition(person.X, person.Y);
                    Console.WriteLine(person.Name);
                    
                }
                Thread.Sleep(1500);
                break; // ta bort denna rad för att låta loopen fortsätta
            }
            Console.ReadKey();


        }
    }
}
