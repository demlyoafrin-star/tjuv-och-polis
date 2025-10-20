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


                people.Add(new Police("P", 15, Random.Shared.Next(1, 99), Random.Shared.Next(1, 23)));
                people.Add(new Thief("T", 15, Random.Shared.Next(1, 99), Random.Shared.Next(1, 23)));
                people.Add(new Citizen("M", 15, Random.Shared.Next(1, 99), Random.Shared.Next(1, 23)));


                foreach (var person in people)
                {
                    Console.SetCursorPosition(person.X, person.Y);
                    Console.WriteLine(person.Name);
                    if (person.X < 99 && person.X > 1 && person.Y < 23 && person.Y > 1)
                    {


                        person.X += 1;
                        person.Y += 1;


                    }


                }
                Thread.Sleep(2000);
                break; // ta bort denna rad för att låta loopen fortsätta

            }

            Console.ReadKey();




        }
    }
}
