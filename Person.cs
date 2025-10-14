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
        public int HowMany { get; set; }

        public Person(string name, int howMany)
        {
            Name = name;
            HowMany = howMany;
        }

    }
    class MedBorgare : Person // Subklass
    {
       public string plånbok { get; set; }
        public MedBorgare(string name, int howMany, string plånbok) : base(name, howMany)
        {
            this.plånbok = plånbok;
        }
    }
    class Polis : Person // Subklass
    {
        public string HandBojor { get; set; }

        public Polis (string name, int howMany, string handBojor) : base(name, howMany)
        {
            HandBojor = handBojor;
        }
    }

    class Tjuv : Person // Subklass
    {
        public string Vapen { get; set; }
        public Tjuv(string name, int howMany, string vapen) : base(name, howMany)
        {
            Vapen = vapen;
        }
    }



}



