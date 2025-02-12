using System;
using System.Xml.Linq;

namespace Cuisines
{
    abstract class Cuisine
    {
        // Property
        public abstract string Name { get; set; }
        public abstract int Age { get; set;}
        // Methods
        public abstract string Describe();
        public string whatAmI()
        {
            return "I am a cusine";
        }
    }
    class Country : Cuisine
        {
            // override the abstract property
            public override string Name { get; set; }
            public override int Age { get; set;}
            public string CountryName { get; set; }
            public string Type { get; set; }

            public Country ()
            {
                Name = string.Empty;
                Age = 0;
                CountryName = string.Empty;
                Type = string.Empty;
            }
            public Country (string name, int age, string country, string type)
            {
                Name = name;
                Age = age;
                CountryName = country;
                Type = type;
            }
            // override the abstract method
            public override string Describe()
            {
                return "I am " + Name + "\nI am " + Age + " years old" +  "\nI originate in " + CountryName + "\nI am " + Type;
            }
        }
    class Program
    {
        static void Main(string[] args)
        {
            // Create Dog object 
            Country india = new Country();
            india.Name = "Indian";
            india.Age = 8000;
            india.CountryName = "India";
            india.Type = "vegetarian";
            Console.WriteLine(india.whatAmI());
            Console.WriteLine(india.Describe());

            Country russian = new Country ("Russian", 1000, "Russia", "mostly meat-based");
            Console.WriteLine(russian.whatAmI());
            Console.WriteLine(russian.Describe());
        }
    }
}