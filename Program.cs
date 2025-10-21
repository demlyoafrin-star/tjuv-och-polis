﻿using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Threading;

namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            City.DrawCity();
            List<Person> people = new List<Person>();
            List<string> newsFeed = new List<string>();




            for (int i = 0; i < 10; i++) // skapar poliser

                people.Add(new Police("P", Random.Shared.Next(2, 99), Random.Shared.Next(2, 23)));

            for (int i = 0; i < 20; i++) // skapar tjubar

                people.Add(new Thief("T", Random.Shared.Next(2, 99), Random.Shared.Next(2, 23)));

            for (int i = 0; i < 30; i++) // skapar medborgare

                people.Add(new Citizen("M", Random.Shared.Next(2, 99), Random.Shared.Next(2, 23)));




            while (true)
            {

                foreach (Person person in people)
                {
                    Console.SetCursorPosition(person.X, person.Y);
                    Console.Write(" "); // Radera personens nuvarande position



                    if (person.X <= 1 || person.X >= 98)
                    {
                        person.Xdirection *= -1; // Vänd riktning horisontellt
                    }
                    if (person.Y <= 1 || person.Y >= 23)
                    {
                        person.Ydirection *= -1; // Vänd riktning vertikalt
                    }

                    person.X += person.Xdirection;
                    person.Y += person.Ydirection;

                    Console.SetCursorPosition(person.X, person.Y);
                    Console.ForegroundColor = person switch
                    {
                        Police => ConsoleColor.Blue,
                        Thief => ConsoleColor.Red,
                        Citizen => ConsoleColor.Green,
                        _ => ConsoleColor.White


                    };

                    Console.Write(person.Name); // Rita personen på den nya positionen
                }

                foreach (Person a in people)
                {
                    foreach (Person b in people)
                    {
                        foreach (Person c in people)
                        {
                            if (a != b && b != c && a != c)
                            {
                                if (a is Citizen citizen && b is Thief thief && c is Police police)
                                {
                                    Interaction.CheckInteration(citizen, thief, police, newsFeed);
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < newsFeed.Count; i++)
                {
                    Console.SetCursorPosition(0, 41 + i);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(newsFeed[i].PadRight(100));
                }



                Thread.Sleep(1000);
                //break; // ta bort denna rad för att låta loopen fortsätta
            }
            Console.ReadKey();
        }
        
       
    }

}