using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TjuvOchPolis
{
    internal static class InteractionManager
    {
        private static List<string> newsFeed = new List<string>();

        public static void HandleInteractions(List<Person> people)
        {

            foreach (var person in people)
            {
                Console.SetCursorPosition(person.X, person.Y);
                Console.Write(" "); // Radera personens nuvarande position

               

                if (person is Thief caughtThief && caughtThief.IsCaught)
                {
                    Tjuv.HandleThiefRelease(caughtThief);
                    Tjuv.MoveInPrison(caughtThief);
                }
                else
                {
                    MoveInCity(person);
                }

                DrawPerson(person);


                
                foreach (var other in people) // polis griper tjuv
                {
                    if (other is Thief thief && !thief.IsCaught &&
                        person is Police &&
                        person.X == other.X && person.Y == other.Y)
                    {
                        // Tjuven blir gripen
                        Tjuv.CatchThief(thief);
                        newsFeed.Add($"Polisen {person.FullName}grep tjuven{thief.FullName} " +
                        $"och ska var i fängelse inom {10 + (thief.Inventory.Count - 1) * 10} sekonder.");
                    }
                }

                
                foreach (var other in people) //tjuv stjäl från medborgare
                {
                    if (other is Thief thief2 && !thief2.IsCaught &&
                        person is Citizen &&
                        other.X == person.X && other.Y == person.Y)
                    {

                        Tjuv.RobsCitizen(thief2, (Citizen)person, newsFeed);
                    }
                }

                foreach (var other in people) // polis hälsar på medborgare
                {
                    if (other is Police police && person is Citizen &&
                        other.X == person.X && other.Y == person.Y)
                    {
                        
                        newsFeed.Add($"Polisen {police.FullName}hälsar på medborgaren{person.FullName}.");
                    }
                }
            }



            // Hantera nyhetsflödet

            int maxVisibleNews = 5;
            int totalNews = newsFeed.Count;
            int startIndex = Math.Max(0, totalNews - maxVisibleNews);
            var visibleNews = newsFeed.Skip(startIndex).Take(maxVisibleNews).ToList();
            // Rensa gamla rader
            for (int i = 0; i < maxVisibleNews; i++)
            {

                Console.SetCursorPosition(0, 29 + i);
                Console.Write(new string(' ', 100));
            }
            // Skriv ut senaste nyheterna med global numrering
            for (int i = 0; i < visibleNews.Count; i++)
            {
                int newsNumber = startIndex + i + 1; // Global numrering
                Console.SetCursorPosition(0, 29 + i);
                //Console.ForegroundColor = ConsoleColor.Blue;
                //Console.WriteLine($"{newsNumber}. {visibleNews[i]}".PadRight(100));

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(newsNumber + ".");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" {visibleNews[i]}".PadRight(100));
            }


            StatusUpdate(people);
            Thread.Sleep(1000);
        }

      

        private static void MoveInCity(Person person)
        {
            person.X += person.Xdirection;
            person.Y += person.Ydirection;


            if (person.X < 1) person.X = 98;
            else if (person.X > 98) person.X = 1;


            if (person.Y < 1) person.Y = 23;
            else if (person.Y > 23) person.Y = 1;
        }
        


        private static void DrawPerson(Person person)
        {
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

        private static void StatusUpdate(List<Person> people)
        {
            int totalThieves = people.Count(p => p is Thief);
            int caughtThieves = people.Count(p => p is Thief t && t.IsCaught);
            int freeThieves = totalThieves - caughtThieves;
            int policeCount = people.Count(p => p is Police);
            int citizenCount = people.Count(p => p is Citizen);

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 25);
            Console.WriteLine($"av {policeCount} poliser, är det nu {policeCount} kvar");
            Console.WriteLine($"Av {citizenCount} medporgare, är det nu {citizenCount} kvar");
            Console.WriteLine($"Av {totalThieves} tjuvar, är det nu {freeThieves} kvar och {caughtThieves} är i fängelse");

            Console.ResetColor();
        }

      
    }
}
