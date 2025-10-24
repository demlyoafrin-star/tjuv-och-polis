using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Threading;
using TjuvOchPolis.TjuvOchPolis;

namespace TjuvOchPolis
{
    public class Program
    {
        // Generat namn på personer i newsfeed

        static List<(string First, string Last)> Names = new() {  ("Bakr", "Svensson"), ("Erik", "Johansson"), ("Sara", "Lindberg"),
                                                                           ("Omar", "Ali"), ("Lisa", "Karlsson"), ("Jonas", "Berg"), ("Nora", "Ahmed"),
                                                                           ("Leo", "Nilsson"), ("Ella", "Persson"), ("Hussein", "Mumin") };

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            City.DrawCity();
            List<Person> people = new List<Person>();
            List<string> newsFeed = new List<string>();
            List<Thief> Prison = new List<Thief>();




            for (int i = 0; i < 10; i++) // skapar poliser
            {
                (string First, string Last) name = Names[(i + 10) % Names.Count];
                people.Add(new Police(name.First, name.Last, Random.Shared.Next(2, 99), Random.Shared.Next(2, 23)));
            }

            for (int i = 0; i < 20; i++) // skapar tjubar
            {
               
                (string First, string Last) name = Names[(i + 20) % Names.Count];
                people.Add(new Thief(name.First, name.Last, Random.Shared.Next(2, 99), Random.Shared.Next(2, 23)));
            }

            for (int i = 0; i < 30; i++) // skapar medborgare
            {
               
                (string First, string Last) name = Names[(i + 30) % Names.Count];
                people.Add(new Citizen(name.First, name.Last, Random.Shared.Next(2, 99), Random.Shared.Next(2, 23)));
            }



            while (true)
            {
                foreach (Person person in people)
                {
                    Console.SetCursorPosition(person.X, person.Y);
                    Console.Write(" ");

                    if (person is Thief thief && Prison.Contains(thief))
                    {
                        // Fängslad tjuv rör sig inom fängelset
                        if (thief.X <= 2 || thief.X >= 13)
                            thief.Xdirection *= -1;

                        if (thief.Y <= 26 || thief.Y >= 33)
                            thief.Ydirection *= -1;

                        thief.X += thief.Xdirection;
                        thief.Y += thief.Ydirection;

                        if (thief.X < 1) thief.X = 1;
                        if (thief.X > 15) thief.X = 15;
                        if (thief.Y < 25) thief.Y = 25;
                        if (thief.Y > 34) thief.Y = 34;


                    }
                    else
                    {
                        // Vanlig rörelse i staden
                        person.X += person.Xdirection;
                        person.Y += person.Ydirection;

                        if (person.X <= 1) person.X = 98;
                        else if (person.X >= 98) person.X = 1;

                        if (person.Y <= 1) person.Y = 23;
                        else if (person.Y >= 23) person.Y = 1;
                    }

                    Console.SetCursorPosition(person.X, person.Y);
                    Console.ForegroundColor = person switch
                    {
                        Police => ConsoleColor.Blue,
                        Thief => ConsoleColor.Red,
                        Citizen => ConsoleColor.Green,
                        _ => ConsoleColor.White
                    };

                    Console.Write(person.Symbol);
                }

                foreach (Citizen citizen in people.OfType<Citizen>())
                {
                    foreach (Thief thief in people.OfType<Thief>())
                    {
                        foreach (Police police in people.OfType<Police>())
                        {
                            InteractionHandler.CheckInteraction(citizen, thief, police, newsFeed, Prison);
                        }
                    }
                }

                for (int i = 0; i < newsFeed.Count; i++)
                {
                    Console.SetCursorPosition(0, 41 + i);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(newsFeed[i].PadRight(100));
                }

                InteractionHandler.PeopleStatus(people, Prison);

                Thread.Sleep(500); // Snabbare uppdatering, ingen paus
            }
        }

       
    }
}