using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Tjuv
    {
        public static void MoveInPrison(Person person)
        {
            if (person.X <= 101 || person.X >= 111)
            {
                person.Xdirection *= -1;
            }
            if (person.Y <= 1 || person.Y >= 9)
            {
                person.Ydirection *= -1;
            }
            person.X += person.Xdirection;
            person.Y += person.Ydirection;
        }

        public static void CatchThief(Thief thief)
        {

            thief.IsCaught = true;
            //thief.Inventory.Clear();

            thief.ReleaseTime = DateTime.Now.AddSeconds(10 + (thief.Inventory.Count -1) * 10);


            thief.X = Random.Shared.Next(102, 109); //fängelse gränser    //ändrade 1 till 2 för att inte skriva över vägg
            thief.Y = Random.Shared.Next(2, 9); //fängelse gränser   //ändrade 25 till 26 för att inte skriva över vägg


            // Console.Beep(500, 600);
           

        }

        public static void HandleThiefRelease(Thief thief)
        {
            if (DateTime.Now >= thief.ReleaseTime)
            {
                // Släpp tjuven tillbaka i staden
                thief.IsCaught = false;
                thief.X = Random.Shared.Next(2, 99); //stadens gränser
                thief.Y = Random.Shared.Next(2, 23); //stadens gränser


              

            }
        }


        public static void RobsCitizen(Thief thief, Citizen citizen, List<string> newsFeed)
        {
            if (citizen.Inventory.Count > 0)
            {
                var itemIndex = Random.Shared.Next(citizen.Inventory.Count);
                var stolenItem = citizen.Inventory[itemIndex];
                citizen.Inventory.RemoveAt(itemIndex);
                thief.Inventory.Add(stolenItem);

                Console.SetCursorPosition(0, 29);
                string message = $"Tjuven {thief.FullName}stal {stolenItem} från medborgaren {citizen.FullName}.";
                

                newsFeed.Add(message);



            }
        }
    }
}
