using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Interaction
    {
        public static void CheckInteration(Citizen citizen, Thief thief, Police police, List<string> newsFeed)
        {
            if (thief.X == citizen.X && thief.Y == citizen.Y)
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

            if (police.X == thief.X && police.Y == thief.Y)
            {
                police.Inventory.AddRange(thief.Inventory);
                thief.Inventory.Clear();

                newsFeed.Add("Polis tar tjuv!");
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
