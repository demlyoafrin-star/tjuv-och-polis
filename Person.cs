using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Person
    {
        public string Name { get; set; } //Basklassen
        public int NumberOfPeople { get; set; }

        public Person(string name, int numberOfPeople)
        {
            Name = name;
            NumberOfPeople = numberOfPeople;
        }

    }
    class MedBorgare : Person // Subklass
    {
       public string plånbok { get; set; }

        public MedBorgare(string name, int numberOfPeople, string plånbok) : base(name, numberOfPeople)
        {
            this.plånbok = plånbok;
        }
    }
    class Polis : Person // Subklass
    {
        public string HandBojor { get; set; }

        public Polis (string name, int numberOfPeople, string handBojor) : base(name, numberOfPeople)
        {
            HandBojor = handBojor;
        }
    }

    class Tjuv : Person // Subklass
    {
        public string Vapen { get; set; }
        public Tjuv(string name, int numberOfPeople, string vapen) : base(name, numberOfPeople)
        {
            Vapen = vapen;
        }
    }



}



