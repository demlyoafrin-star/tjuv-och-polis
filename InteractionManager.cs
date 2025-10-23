using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal static class InteractionManager
    {
        public static void HandleInteractions(List<Person> people)
        {
            
            foreach (var person in people)
            {
                Console.SetCursorPosition(person.X, person.Y);
                Console.Write(" "); // Radera personens nuvarande position



                if (person is Thief caughtThief && caughtThief.IsCaught)
                {
                    if (DateTime.Now >= caughtThief.ReleaseTime)
                    {
                        // Släpp tjuven tillbaka i staden
                        caughtThief.IsCaught = false;
                        caughtThief.X = Random.Shared.Next(2, 99); //stadens gränser
                        caughtThief.Y = Random.Shared.Next(2, 23); //stadens gränser
                        Console.SetCursorPosition(0, 42);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"Tjuven är nu frigiven och återvänder till staden den {DateTime.Now.TimeOfDay}      ");
                        Console.ResetColor();
                        Console.Beep(700, 200);
                    }

                    if (person.X <= 1 || person.X >= 14)
                    {
                        person.Xdirection *= -1;
                    }
                    if (person.Y <= 25 || person.Y >= 34)
                    {
                        person.Ydirection *= -1;
                    }
                }
                else
                {
                    // Vanlig rörelse i staden
                    if (person.X <= 1 || person.X >= 99)
                    {
                        person.Xdirection *= -1;
                    }
                    if (person.Y <= 1 || person.Y >= 23)
                    {
                        person.Ydirection *= -1;
                    }
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
                Console.Write(person.Name); // Ritar personen på den nya positionen


                foreach (var other in people)
                {
                    if (other is Thief thief && !thief.IsCaught &&
                        person is Police &&
                        person.X == other.X && person.Y == other.Y)
                    {
                        // Tjuven blir gripen
                        thief.IsCaught = true;
                        thief.ReleaseTime = DateTime.Now.AddSeconds(10); // Tjuven släpps efter 40 sekunder
                        thief.X = Random.Shared.Next(2, 14); //fängelse gränser    //ändrade 1 till 2 för att inte skriva över vägg
                        thief.Y = Random.Shared.Next(26, 34); //fängelse gränser   //ändrade 25 till 26 för att inte skriva över vägg
                                                              // Console.Beep(500, 600);




                        Console.SetCursorPosition(0, 41);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"En tjuv har blivit gripen och sitter i fängelse tills {thief.ReleaseTime:T}");
                        Console.ResetColor();





                    }
                }

             

            }
            Thread.Sleep(200);
            //break; // ta bort denna rad för att låta loopen fortsätta







        }
    }
}
