using System;

namespace delegatesAndEvents
{
     // create a delegate
     public delegate void RaceEventHandler(int winner);

    public class Race
    {
        // create a delegate event object
        public event RaceEventHandler footRace;
        public event RaceEventHandler carRace;
        public event RaceEventHandler BikeRace;

        public void Racing(int contestants, int laps)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new Random();
            int[] participants = new int[contestants];
            bool done = false;
            int champ = -1;
            // first to finish specified number of laps wins
            while (!done)
            {
                for (int i = 0; i < contestants; i++)
                {

                    if (participants[i] <= laps)
                    {
                        participants[i] += r.Next(1, 5);
                    }
                    else
                    {
                        champ = i;
                        done = true;
                        continue;
                    }
                }

            }

            TheWinner(champ);
        }
        private void TheWinner(int champ)
        {
            Console.WriteLine("We have a winner!");
            // invoke the delegate event object and pass champ to the method
            footRace?.Invoke(champ);
            carRace?.Invoke(champ);
            BikeRace?.Invoke(champ);
        }
    }
    class Program
    {
        public static void Main()
        {
            // create a class object
            Race round1 = new Race();
            // register with the footRace event
            round1.footRace += footRace;

            // register with the carRace event
            round1.carRace += carRace;

            // register a bike race event using a lambda expression
            round1.BikeRace += winner => 
            {
                Console.WriteLine($"Bike number {winner} is the winner.");
            };
 
            // trigger the event
            round1.Racing(10, 20);

        }

        // event handlers
        public static void carRace(int winner)
        {
            Console.WriteLine($"Car number {winner} is the winner.");
        }
        public static void footRace(int winner)
        {
            Console.WriteLine($"Racer number {winner} is the winner.");
        }
    }
}