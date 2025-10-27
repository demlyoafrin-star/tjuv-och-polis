using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Threading;
using System.Net.NetworkInformation;//Detta behövs för Thread.Sleep

namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
         


            Console.CursorVisible = false;
            City.DrawCity();
            

            List<Person> people = new List<Person>();


            for (int i = 0; i < 10; i++) // skapar antal poliser

                people.Add(new Police("P", Random.Shared.Next(2, 99), Random.Shared.Next(2, 23)));

            for (int i = 0; i < 20; i++) // skapar antal tjubar

                people.Add(new Thief("T", Random.Shared.Next(2, 99), Random.Shared.Next(2, 23), false));

            for (int i = 0; i < 30; i++) // skapar antal medborgare

                people.Add(new Citizen("M", Random.Shared.Next(2, 99), Random.Shared.Next(2, 23)));


            while (true)
            {
                InteractionManager.HandleInteractions(people);

    
              
            }

            Console.ReadKey();

        }
    }
}

