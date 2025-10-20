using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Person //Base class
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<string> Inventory { get; set; }
        public int Xdirection { get; set; }
        public int Ydirection { get; set; }

        public Person(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
            Inventory = new List<string>();
            
            Xdirection = Random.Shared.Next(-1, 2); // -1, 0, or 1
            Ydirection = Random.Shared.Next(-1, 2); // -1, 0, or 1

            if ( Xdirection == 0 && Ydirection == 0) // Ensure the person moves
            {
                Xdirection = 1; // Default to moving right if both are 0
            }

        }
    }
    public class Citizen : Person // subklass för medborgare
    {

        public Citizen(string name, int x, int y) : base(name, x, y)
        {
            Inventory.Add("Keys");
            Inventory.Add("Mobile");
            Inventory.Add("Wallet");
            Inventory.Add("Watch");
            
        }
    }

    public class Thief : Person // subklass för tjuv
    {
        public Thief(string name, int x, int y) : base(name, x, y)
        {
            Inventory.Add("Knife");
            
        }
    }

    public class Police : Person // subklass för polis
    {
        public Police(string name, int x, int y) : base(name, x, y)
        {
            Inventory.Add("Handcuffs");
            Inventory.Add("Weapon");
            
        }
    }
}


    




