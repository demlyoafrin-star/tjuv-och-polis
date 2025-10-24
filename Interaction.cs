using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    namespace TjuvOchPolis
    {
        public static class InteractionHandler
        {
            public static void CheckInteraction(Citizen citizen, Thief thief, Police police, List<string> newsFeed, List<Thief> Prison)
            {
                if (thief.X == citizen.X && thief.Y == citizen.Y && !Prison.Contains(thief))
                {
                    if (citizen.Inventory.Count > 0)
                    {
                        int index = Random.Shared.Next(citizen.Inventory.Count);
                        string item = citizen.Inventory[index];

                        citizen.Inventory.RemoveAt(index);
                        thief.Inventory.Add(item);

                        newsFeed.Add($"Tjuv {thief.FullName} rånar medborgare {citizen.FullName} på {item}!");
                        newsFeed.Add($"Medborgare {citizen.FullName} blir bestulen av {thief.FullName}!");
                    }
                }

                if (police.X == thief.X && police.Y == thief.Y && !Prison.Contains(thief))
                {
                    police.Inventory.AddRange(thief.Inventory);
                    thief.Inventory.Clear();

                    // Flytta tjuven till fängelset
                    int prisonX = Random.Shared.Next(1, 15);     // fängelsets bredd
                    int prisonY = Random.Shared.Next(25, 34);    // fängelsets höjd
                    thief.X = prisonX;
                    thief.Y = prisonY;

                    Prison.Add(thief);
                    newsFeed.Add($"Polis {police.FullName} griper tjuv {thief.FullName} efter rån mot {citizen.FullName}.");
                    newsFeed.Add($"{police.FullName} fångar {thief.FullName} efter rån mot {citizen.FullName}.");
                    newsFeed.Add($"Efter rånet mot {citizen.FullName} griper {police.FullName} {thief.FullName}.");
                }

                if (police.X == citizen.X && police.Y == citizen.Y)
                {
                    newsFeed.Add($"Polis {police.FullName} hälsar på medborgare {citizen.FullName}.");
                    newsFeed.Add($"Polis {police.FullName} vinkar till {citizen.FullName}.");
                    newsFeed.Add($"{police.FullName} nickar vänligt mot {citizen.FullName}.");
                }

                if (newsFeed.Count > 4)
                    newsFeed.RemoveAt(0);
            }


            public static void PeopleStatus(List<Person> people, List<Thief> Prison)
            {
                int y = 36;

                Console.SetCursorPosition(0, y++);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Antal poliser: " + CountType<Police>(people));

                Console.SetCursorPosition(0, y++);
                Console.WriteLine("Antal medborgare: " + CountType<Citizen>(people));

                Console.SetCursorPosition(0, y++);
                Console.WriteLine("Antal tjuvar: " + CountType<Thief>(people));

                Console.SetCursorPosition(0, y++);
                Console.WriteLine("Antal fängslade tjuvar: " + Prison.Count);

                Console.ResetColor();
            }

            static int CountType<RoleType>(List<Person> people) where RoleType : Person
            {
                return people.Count(p => p is RoleType);
            }
        }
    }
}