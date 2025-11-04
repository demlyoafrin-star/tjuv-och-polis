using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace TjuvOchPolis
{
    internal static class InteractionManager
    {
        private static List<string> newsFeed = new List<string>();

        public static void HandleInteractions(List<Person> people)
        {
            // Viktigt: sätta UTF8 så konsolen kan visa emojis/Unicode.
            Console.OutputEncoding = Encoding.UTF8;
            //Console.InputEncoding = Encoding.UTF8;


            File.WriteAllLines("newsFeed.txt",
            newsFeed.Select((line, index) => $"{index + 1}. {line}"));





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

                        newsFeed.Add($"Polisen {person.FullName}grep tjuven {thief.FullName} " +
                        $"och ska var i fängelse inom {10 + (thief.Inventory.Count - 1) * 10} sekonder  🚨");

                        person.Inventory.AddRange(thief.Inventory);
                        thief.Inventory.RemoveAll(thief.Inventory.Contains);

                        //för att visa vad tjuven hade på sig när han blev gripen
                        //newsFeed.Add("Polisen hittade / " + string.Join(", ", person.Inventory) + " / hos tjuven");

                        Console.Beep(600, 400);
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
                        newsFeed.Add($"Polisen {police.FullName}hälsar på medborgaren {person.FullName}  👋 ");
                    }
                    
                }
            }


            // Hantera news feed
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

            // Skriv ut senaste nyheterna i omvänd ordning (nyaste överst)
            for (int i = 0; i < visibleNews.Count; i++)
            {
                // räkna bakifrån
                int reversedIndex = visibleNews.Count - 1 - i; // Index för att få nyaste först
                int newsNumber = totalNews - i; 

                // skriv högst upp, sedan nedåt
                Console.SetCursorPosition(0, 29 + i);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(newsNumber + ".");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" {visibleNews[reversedIndex]}".PadRight(100));
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
            // Rita personen på dess nya position
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
            // Räkna tjuvar, medborgare och poliser
            int totalThieves = people.Count(p => p is Thief);
            int caughtThieves = people.Count(p => p is Thief t && t.IsCaught);
            int freeThieves = totalThieves - caughtThieves;

            int citizenCount = people.Count(p => p is Citizen);
            int robbedCitizens = people.Count(p => p is Citizen c && c.IsRobbed);

            int policeCount = people.Count(p => p is Police);


            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 25);


            // poliser
            Console.Write("av");
            Console.ForegroundColor = ConsoleColor.DarkYellow;Console.Write(policeCount);
            Console.ForegroundColor = ConsoleColor.White; Console.Write(" poliser, är det nu lika många kvar \n");


            // medborgare
            Console.Write("Av ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;Console.Write(citizenCount);
            Console.ForegroundColor = ConsoleColor.White;Console.Write(" medborgare, är det nu ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;  Console.Write(robbedCitizens);
            Console.ForegroundColor = ConsoleColor.White;  Console.Write(" som har blivit rånade \n");



            // tjuvar
            Console.Write("Av ");
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(totalThieves);
            Console.ForegroundColor = ConsoleColor.White; Console.Write(" tjuvar, är det nu ");
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(freeThieves);
            Console.ForegroundColor = ConsoleColor.White;  Console.Write(" kvar och ");
            Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(caughtThieves);
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(" är i fängelse ");

            Console.ResetColor();
        }

      
    }
}
