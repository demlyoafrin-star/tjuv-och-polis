﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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


                //tjuv stjäl från medborgare
                foreach (var other in people)
                {
                    if (other is Thief thief2 && !thief2.IsCaught &&
                        person is Citizen &&
                        other.X == person.X && other.Y == person.Y)
                    {
                        // Tjuven stjäl från medborgaren        
                        RobsCitizen(thief2, (Citizen)person);


                    }
                }


            }
            StatusUpdate(people);
            Thread.Sleep(200);
        }




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

        private static void MoveInPoliceStation (Person person)
        {
            if (person.X <= 17 || person.X >= 28)
            {
                person.Xdirection *= -1;
            }
            if (person.Y <= 29 || person.Y >= 32)
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
            Console.ForegroundColor = ConsoleColor.Blue;
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
                
            }
        }


        private static void RobsCitizen(Thief thief, Citizen citizen)
        {
            if (citizen.Inventory.Count > 0)
            {
                var itemIndex = Random.Shared.Next(citizen.Inventory.Count);
                var stolenItem = citizen.Inventory[itemIndex];
                citizen.Inventory.RemoveAt(itemIndex);
                thief.Inventory.Add(stolenItem);
                Console.SetCursorPosition(0, 40);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Tjuven stal {stolenItem} från medborgaren!");
                Console.ResetColor();
                

            }
            //else if (citizen.Inventory.Count == 0)
            //{
            //    citizen.X = 25;
            //    citizen.Y = 30;
            //    citizen.Xdirection = 1;
            //    citizen.Ydirection = 1;
            //    MoveInPoliceStation(citizen);

            //}


        }

        private static void StatusUpdate(List<Person> people)
        {
            int totalThieves = people.Count(p => p is Thief);
            int caughtThieves = people.Count(p => p is Thief t && t.IsCaught);
            int freeThieves = totalThieves - caughtThieves;
            int policeCount = people.Count(p => p is Police);
            int citizenCount = people.Count(p => p is Citizen);

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 36); // välj rad i konsolen där status ska stå
            Console.WriteLine($"av {policeCount} poliser, är det nu {policeCount} kvar");
            Console.WriteLine($"Av {citizenCount} medporgare, är det nu {citizenCount} kvar");
            Console.WriteLine($"Av {totalThieves} tjuvar, är det nu {freeThieves} kvar och {caughtThieves} är i fängelse");

            Console.ResetColor();
        }


    }
}
