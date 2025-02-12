interface IEmployee
{
    //Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //Methods
    public string Fullname();
    public string Pay();
}
class Employee : IEmployee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Employee()
    {
        Id = 0;
        FirstName = string.Empty;
        LastName = string.Empty;
    }
    public Employee(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    public string Fullname()
    {
        return FirstName + " " + LastName;
    }
    public virtual string Pay()
    {
        double salary;
        Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
        salary = double.Parse(Console.ReadLine());
        return "salary";
    }

}
class Program 
{
    class Executive : Employee
    {
        public string Title { get; set; }
        public double Salary { get; set; }

        public Executive() :base()
        {
            Title = string.Empty;
            Salary = 0;
        }
        public Executive(int id, string firstName, string lastName, string title, double salary)
            :base(id,firstName, lastName) 
        {
            Title = title;
            Salary = salary;
        }

        sealed public override string Pay()
        {
            double hourlyWage = Salary/12/20/8;
            return "Hourly Wage: " + hourlyWage;
        }
    }
    static void Main(string[] args)
        {
            // Employee object
            Employee mike= new Employee(500,"Mike","Novikov");
            mike.Pay();

            // Executive object created using parameterized constructor
            Executive brad = new Executive(1000, "Brad", "O'Brien", "General Manager", 80000);
            Console.WriteLine(brad.Fullname());
            Console.WriteLine(brad.Pay());

            //Eecutive object created using the default constructor
            //values are assigned using properties
            Executive steven = new Executive();
            steven.Id = 299;
            steven.FirstName = "Steven";
            steven.LastName = "Spohn";
            steven.Title = "Substitute Teacher";
            steven.Salary = 45000;
            Console.WriteLine(steven.Fullname());
            Console.WriteLine(steven.Pay());
        }
}

