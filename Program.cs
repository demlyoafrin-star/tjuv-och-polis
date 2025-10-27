using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Threading;
using System.Net.NetworkInformation;//Detta behövs för Thread.Sleep

namespace TjuvOchPolis
{
    internal class Program
    {

        // Generat namn på personer i newsfeed

        static List<(string First, string Last)> Names = new() {  ("Bakr", "Svensson"), ("Erik", "Johansson"), ("Sara", "Lindberg"),
                                                                           ("Omar", "Ali"), ("Lisa", "Karlsson"), ("Jonas", "Berg"), ("Nora", "Ahmed"),
                                                                           ("Leo", "Nilsson"), ("Ella", "Persson"), ("Hussein", "Mumin") };

        static void Main(string[] args)
        {
         




            Console.CursorVisible = false;
            City.DrawCity();
            

            List<Person> people = new List<Person>();
            List<string> newsFeed = new List<string>();


            for (int i = 0; i < 10; i++) // skapar poliser
            {
                (string First, string Last) name = Names[(i + 10) % Names.Count];
                people.Add(new Police(name.First, name.Last, Random.Shared.Next(2, 99), Random.Shared.Next(2, 23)));
            }

            for (int i = 0; i < 20; i++) // skapar tjubar
            {

                (string First, string Last) name = Names[(i + 20) % Names.Count];
                people.Add(new Thief(name.First, name.Last, Random.Shared.Next(2, 99), Random.Shared.Next(2, 23), false));
            }

            for (int i = 0; i < 30; i++) // skapar medborgare
            {

                (string First, string Last) name = Names[(i + 30) % Names.Count];
                people.Add(new Citizen(name.First, name.Last, Random.Shared.Next(2, 99), Random.Shared.Next(2, 23)));
            }


            while (true)
            {
                InteractionManager.HandleInteractions(people);


            }

            Console.ReadKey();

        }
    }
}

