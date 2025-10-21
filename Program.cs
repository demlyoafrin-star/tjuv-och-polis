using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Threading;//Detta behövs för Thread.Sleep

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

            for (int i = 0; i < 40; i++) // skapar antal tjubar

                people.Add(new Thief("T", Random.Shared.Next(2, 99), Random.Shared.Next(2, 23), false));

            for (int i = 0; i < 30; i++) // skapar antal medborgare

                people.Add(new Citizen("M", Random.Shared.Next(2, 99), Random.Shared.Next(2, 23)));

            while (true)
            {

                foreach (var person in people)
                {
                    Console.SetCursorPosition(person.X, person.Y);
                    Console.Write(" "); // Radera personens nuvarande position



                    if (person is Thief caughtThief && caughtThief.IsCaught)
                    {
                        if (person.X <= 1 || person.X >= 14)
                        {
                            person.Xdirection *= -1;
                        }
                        if (person.Y <= 25 || person.Y >= 34)
                        {
                            person.Ydirection *= -1;
                        }
                    }
                    
                    else 
                    {
                        // Vanlig rörelse i staden
                        if (person.X <= 1 || person.X >= 99)
                        {
                            person.Xdirection *= -1;
                        }
                        if (person.Y <= 1 || person.Y >= 23)
                        {
                            person.Ydirection *= -1;
                        }
                    }


                    person.X += person.Xdirection;
                    person.Y += person.Ydirection;

                    Console.SetCursorPosition(person.X, person.Y);
                    Console.ForegroundColor = person switch
                    {
                        Police => ConsoleColor.Blue,
                        Thief => ConsoleColor.Red,
                        Citizen => ConsoleColor.Green,
                        _ => ConsoleColor.White
                    };
                    Console.Write(person.Name); // Rita personen på den nya positionen


                    foreach (var other in people)
                    {
                        if (other is Thief thief && !thief.IsCaught &&
                            person is Police &&
                            person.X == other.X && person.Y == other.Y)
                        {
                            thief.IsCaught = true;
                            Console.SetCursorPosition(0, 41);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"A thief has been caught at ({thief.X}, {thief.Y})!          ");
                            Console.ResetColor();

                            if (thief.IsCaught)
                            {
                                Console.SetCursorPosition(thief.X = Random.Shared.Next(1,14), thief.Y = Random.Shared.Next(25, 34));

                            }
                        }
                    }



                }


                Thread.Sleep(50);
                //break; // ta bort denna rad för att låta loopen fortsätta

            }

            Console.ReadKey();

        }
    }
}

