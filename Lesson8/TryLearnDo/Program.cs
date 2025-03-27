using System;

namespace delegatesAndEvents
{
    public delegate void Notify(int n);  // delegate

    public class Picnic
    {
        public event Notify ContestEnd; // event

        public void EatingContest(int contestants)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new Random();
            int[] foodEaten= new int[contestants];
            bool done = false;
            int champ = -1;
            while (!done)
            {
                // each contestant's amount of food eaten is calculated
                // until one of the contestants reaches 100
                for (int i = 0; i < contestants; i++)
                {

                    if (foodEaten[i] <= 100)
                    {
                        foodEaten[i] += r.Next(1, 5);
                    }
                    else { 
                        champ = i; //contestant number of the winner
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
            ContestEnd(champ);   // Triggers the event
        }
    }
    class Program
    {
        public static void Main()
        {
            // create a class object
            Picnic contest = new Picnic();
            // register with an event
            contest.ContestEnd += hotdog_contestEnd;
            // trigger the event
            contest.EatingContest(80);
            // register with a different event
            contest.ContestEnd-= hotdog_contestEnd;
            contest.ContestEnd+= pie_contestEnd;
            //trigger the event
            contest.EatingContest(20);
            // register with a different event using a lambda expression
            contest.ContestEnd -= pie_contestEnd;
            contest.ContestEnd += (winner) => Console.WriteLine($"The cookie eating competition winner is {winner}");
            // trigger the event
            contest.EatingContest(30);
        }

        // event handlers
        public static void hotdog_contestEnd(int winner)
        {
            Console.WriteLine($"The hotdog eating competition winner is {winner}");
        }
        public static void pie_contestEnd(int winner)
        {
            Console.WriteLine($"The pie eating competition winner is {winner}");
        }
    }
}