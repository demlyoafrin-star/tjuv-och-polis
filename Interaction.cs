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
            public static void CheckInteraction(Citizen citizen, Thief thief, Police police, List<string> newsFeed, List<Thief> Inmates)
            {
                if (thief.X == citizen.X && thief.Y == citizen.Y && !Inmates.Contains(thief))
                {
                    if (citizen.Inventory.Count > 0)
                    {
                        int index = Random.Shared.Next(citizen.Inventory.Count);
                        string item = citizen.Inventory[index];

                        citizen.Inventory.RemoveAt(index);
                        thief.Inventory.Add(item);

                        newsFeed.Add($"Tjuv rånar medborgare på {item}!");
                    }
                }

                if (police.X == thief.X && police.Y == thief.Y && !Inmates.Contains(thief))
                {
                    police.Inventory.AddRange(thief.Inventory);
                    thief.Inventory.Clear();

                    // Flytta tjuven till fängelset
                    int prisonX = Random.Shared.Next(1, 15);     // fängelsets bredd
                    int prisonY = Random.Shared.Next(25, 34);    // fängelsets höjd
                    thief.X = prisonX;
                    thief.Y = prisonY;

                    Inmates.Add(thief);
                    newsFeed.Add("Polis tar tjuv! Tjuven skickas till fängelset.");
                }

                if (police.X == citizen.X && police.Y == citizen.Y)
                {
                    newsFeed.Add("Polis hälsar på medborgare!");
                }

                if (newsFeed.Count > 4)
                    newsFeed.RemoveAt(0);
            }
        }
    }
}