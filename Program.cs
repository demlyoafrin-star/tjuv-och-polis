using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Threading;
using System.Net.NetworkInformation;//Detta behövs för Thread.Sleep

namespace TjuvOchPolis
{
    internal class Program
    {

        static List<(string First, string Last)> Names = new() {  ("Bakr", ""), ("Erik", ""), ("Sara", ""),
                                                                  ("Omar", ""), ("Lisa", ""), ("Jonas", ""), ("Nora", ""),
                                                                  ("Leo", ""), ("Ella", "Persson"), ("Hussein", ""), ("Oliver", ""),
                                                                   ("Jonas", ""), ("Kristofer", ""), ("Qudsia", "")};


    static void Main(string[] args)
        {
            Console.CursorVisible = false;
            City.DrawCity();


            List<Person> people = new List<Person>();
            List<string> newsFeed = new List<string>();


            for (int i = 0; i < 20; i++) // skapar poliser
            {
                (string First, string Last) name = Names[(i + 10) % Names.Count];
                people.Add(new Police(name.First, name.Last, Random.Shared.Next(2, 99), Random.Shared.Next(2, 23)));
            }

            for (int i = 0; i < 20; i++) // skapar tjuvar
            {
                (string First, string Last) name = Names[(i + 20) % Names.Count];
                people.Add(new Thief(name.First, name.Last, Random.Shared.Next(2, 99), Random.Shared.Next(2, 23), false));
            }

            for (int i = 0; i < 30; i++) // skapar medborgare
            {
                (string First, string Last) name = Names[(i + 30) % Names.Count];
                people.Add(new Citizen(name.First, name.Last, Random.Shared.Next(2, 99), Random.Shared.Next(2, 23), false));
            }


            while (true)
            {
                InteractionManager.HandleInteractions(people);


            }
        }
    }
}