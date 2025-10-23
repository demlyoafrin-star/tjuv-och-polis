using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal static class InteractionManager
    {
        private static void MoveInCity(Person person)
        {
            if (person.X <= 1 || person.X >= 99)
            {
                person.Xdirection *= -1;
            }
            if (person.Y <= 1 || person.Y >= 23)
            {
                person.Ydirection *= -1;
            }
            person.X += person.Xdirection;
            person.Y += person.Ydirection;
        }
        

        private static void MoveInPrison(Person person)
        {
            if (person.X <= 1 || person.X >= 14)
            {
                person.Xdirection *= -1;
            }
            if (person.Y <= 25 || person.Y >= 34)
            {
                person.Ydirection *= -1;
            }
            person.X += person.Xdirection;
            person.Y += person.Ydirection;
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
            Console.Write(person.Name);
        }


        private static void CatchThief(Thief thief) 
        {
            
            thief.IsCaught = true;
            thief.ReleaseTime = DateTime.Now.AddSeconds(10); // Tjuven släpps efter 40 sekunder
            thief.X = Random.Shared.Next(2, 14); //fängelse gränser    //ändrade 1 till 2 för att inte skriva över vägg
            thief.Y = Random.Shared.Next(26, 34); //fängelse gränser   //ändrade 25 till 26 för att inte skriva över vägg


            Console.Beep(500, 600);
            Console.SetCursorPosition(0, 41);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"En tjuv har blivit gripen och sitter i fängelse tills {thief.ReleaseTime:T}");
            Console.ResetColor();

        }

        private static void HandleThiefRelease(Thief thief)
        {
            if (DateTime.Now >= thief.ReleaseTime)
            {
                // Släpp tjuven tillbaka i staden
                thief.IsCaught = false;
                thief.X = Random.Shared.Next(2, 99); //stadens gränser
                thief.Y = Random.Shared.Next(2, 23); //stadens gränser


                Console.SetCursorPosition(0, 42);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Tjuven är nu frigiven {DateTime.Now:T}      ");
                Console.ResetColor();
                Console.Beep(700, 200);
            }
        }






        public static void HandleInteractions(List<Person> people)
        {

            foreach (var person in people)
            {
                Console.SetCursorPosition(person.X, person.Y);
                Console.Write(" "); // Radera personens nuvarande position



                if (person is Thief caughtThief && caughtThief.IsCaught)
                {
                    HandleThiefRelease(caughtThief);
                    MoveInPrison(caughtThief);
                }
                else
                {
                    MoveInCity(person);
                }

                DrawPerson(person);


                //polis griper tjuv
                foreach (var other in people)
                {
                    if (other is Thief thief && !thief.IsCaught &&
                        person is Police &&
                        person.X == other.X && person.Y == other.Y)
                    {
                        // Tjuven blir gripen
                        CatchThief(thief);
                    }
                }
            }
            Thread.Sleep(200);
          







        }
    }
}
