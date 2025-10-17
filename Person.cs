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
        public int ManyOfPeople { get; set; } // Nytt property för att hålla koll på antal personer
        public int X { get; set; }
        public int Y { get; set; }
        public List<string> Inventory { get; set; }

        public Person(string name, int manyOfPeople, int x, int y)
        {
            Name = name;
            ManyOfPeople = manyOfPeople;
            X = x = Random.Shared.Next(1, 99);
            Y = y = Random.Shared.Next(1, 23);
            Inventory = new List<string>();
            
         }
    }
    public class Citizen : Person // subklass för medborgare
    {

        public Citizen(string name,int manyOfPeople, int x, int y) : base(name,manyOfPeople, x, y)
        {
            
            Inventory.Add("Keys");
            Inventory.Add("Mobile");
            Inventory.Add("Wallet");
            Inventory.Add("Watch");
        }
    }

    public class Thief : Person // subklass för tjuv
    {
        public Thief(string name,int manyOfPeople, int x, int y) : base(name, manyOfPeople, x, y)
        {
            Inventory.Add("Knife");

        }
    }

    public class Police : Person // subklass för polis
    {
        public Police(string name,int manyOfPeople, int x, int y) : base(name,manyOfPeople, x, y)
        {
            Inventory.Add("Handcuffs");
            Inventory.Add("Weapon");
        }
    }
}


    




