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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}"; // Fullständigt namn
        public virtual string Symbol => "?";            // Bokstav som visas i staden


        public int X { get; set; }
        public int Y { get; set; }
        public List<string> Inventory { get; set; }
        public int Xdirection { get; set; }
        public int Ydirection { get; set; }

        public Person(string firstName, string lastName, int x, int y)
        {
            FirstName = firstName;
            LastName = lastName;
            X = x;
            Y = y;
            Inventory = new List<string>();

            Xdirection = Random.Shared.Next(-1, 2); // -1, 0, or 1
            Ydirection = Random.Shared.Next(-1, 2); // -1, 0, or 1

            if (Xdirection == 0 && Ydirection == 0) // Ensure the person moves
            {
                Xdirection = 1; // Default to moving right if both are 0
            }

        }
    }
    public class Citizen : Person // subklass för medborgare
    {
        public override string Symbol => "M"; // Medborgare visas som M
        public Citizen(string firstName, string lastName, int x, int y) : base(firstName, lastName, x, y)
        {
            Inventory.Add("Keys");
            Inventory.Add("Mobile");
            Inventory.Add("Wallet");
            Inventory.Add("Watch");

        }
    }

    public class Thief : Person // subklass för tjuv
    {
        public override string Symbol => "T"; // Tjuv visas som T
        public Thief(string firstName, string lastName, int x, int y) : base(firstName, lastName, x, y)
        {
            Inventory.Add("Knife");

        }
    }

    public class Police : Person // subklass för polis
    {
        public override string Symbol => "P"; // Polis visas som P
        public Police(string firstName, string lastName, int x, int y) : base(firstName, lastName, x, y)
        {
            Inventory.Add("Handcuffs");
            Inventory.Add("Weapon");

        }
    }
}


