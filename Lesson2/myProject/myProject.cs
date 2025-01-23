using System;

namespace myProject
{
    class fitness
    {
        private int Id;
        private string _Workout;
        private string _Focus;
        private static int _transactions = 0;

        public fitness ()
        {
            Id = 0;
            _Workout = "";
            _Focus= "";
        }

        public fitness (int id, string workout, string focus)
        {
            Id = id;
            _Workout = workout;
            _Focus = focus;
        }

        public int GetId ()
        {
            return Id;
        }
        public string GetWorkout ()
        {
            return _Workout;
        }
        public string GetFocus ()
        {
            return _Focus;
        }
        public void SetId (int id)
        {
            Id = id;
        }
        public void SetWorkout (string workout)
        {
            _Workout = workout;
        }
        public void SetFocus (string focus)
        {
            _Focus = focus;
        }

        public void SetTrans ()
        {
            _transactions++;
        }

        public int GetTrans ()
        {
            return _transactions;
        }
    }
    class myStore
    {
        static void Main(string[] args)
        {
            fitness fitness1 = new fitness ();
            fitness1.SetTrans();
            fitness1.SetId (1);
            fitness1.SetWorkout ("Strength Training");
            fitness1.SetFocus ("Build muscle");

            fitness fitness2 = new fitness ();
            fitness2.SetTrans();
            Console.WriteLine("Please enter the member ID: ");
            fitness2.SetId(int.Parse(Console.ReadLine()));
            Console.WriteLine("Please enter the workout: ");
            fitness2.SetWorkout(Console.ReadLine());
            Console.WriteLine("Please enter the focus: ");
            fitness2.SetFocus(Console.ReadLine());

            fitness fitness3 = new fitness (1, "Yoga", "Piece of mind");
            fitness3.SetTrans();

            Console.WriteLine("Please enter the member ID: ");
            int tempID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the workout: ");
            string tempWorkout = Console.ReadLine();   
            Console.WriteLine("Please enter the focus: ");
            string tempFocus = Console.ReadLine();
            fitness fitness4 = new fitness (tempID, tempWorkout, tempFocus);
            fitness4.SetTrans();

            Console.WriteLine($"There are {fitness1.GetTrans()} workouts.");

            displayBooks(fitness1);
            displayBooks(fitness2);
            displayBooks(fitness3);
            displayBooks(fitness4);
        }

        static void displayBooks(fitness fitness1)
        {
            Console.WriteLine("Here is your fitness information");
            Console.WriteLine($"Member ID: {fitness1.GetId()}");
            Console.WriteLine($"Title: {fitness1.GetWorkout()}");
            Console.WriteLine($"Author: {fitness1.GetFocus()}");
        }
    }
}