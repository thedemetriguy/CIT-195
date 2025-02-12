using System;
namespace Employees
{
    interface IClub
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Methods
        public string Fullname();
    }
    class Program
    {
        class Athlete : IClub
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Salary { get; set; }
            public string Sport { get; set; }
            public string Country { get; set; }

            public Athlete()
            {
                Id = 0;
                FirstName = string.Empty;
                LastName = string.Empty;
                Salary = 0;
                Sport = string.Empty;
                Country = string.Empty;
            }
            public Athlete(int id, string firstName, string lastName, double salary, string sport, string country)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
                Salary = salary;
                Sport = sport;
                Country = country;
            }

            public string Fullname()
            {
                return FirstName + " " + LastName;
            }
            public void AdditonalInformation()
            {
                Console.WriteLine($"Country: {Country}\nSport: {Sport}\nSalary: {Salary}");
                return;
            }
        }
        static void Main(string[] args)
        {
            // Worker object created using parameterized constructor
            Athlete dmitry = new Athlete(299,"Dmitry","Novikov", 100000, "Swimming", "Russia");
            Console.WriteLine(dmitry.Fullname());
            dmitry.AdditonalInformation();

            //Worker object created using the default constructor
            //values are assigned using properties
            Athlete alex = new Athlete();
            alex.Id = 20;
            alex.FirstName = "Alex";
            alex.LastName = "Novikov";
            alex.Salary = 200000;
            alex.Sport = "Track & Field";
            alex.Country = "Russia";
            Console.WriteLine(alex.Fullname());
            alex.AdditonalInformation();

        }
    }
}