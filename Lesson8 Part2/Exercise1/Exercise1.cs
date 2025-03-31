using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise1
{
    public class FamousPeople
    {
        public string Name { get; set; }
        public int? BirthYear { get; set; } = null;
        public int? DeathYear { get; set; } = null;

        // Override ToString to provide a formatted string for each person
        public override string ToString()
        {
            if (BirthYear.HasValue && DeathYear.HasValue)
                return $"{Name} ({BirthYear} - {DeathYear})";
            else if (BirthYear.HasValue)
                return $"{Name} (Born {BirthYear})";
            else if (DeathYear.HasValue)
                return $"{Name} (Died {DeathYear})";
            else
                return Name;
        }
    }

    class Program
    {
        // Static list of famous STEM people
        static IList<FamousPeople> stemPeople = new List<FamousPeople>()
        {
            new FamousPeople() { Name = "Michael Faraday", BirthYear = 1791, DeathYear = 1867 },
            new FamousPeople() { Name = "James Clerk Maxwell", BirthYear = 1831, DeathYear = 1879 },
            new FamousPeople() { Name = "Marie Skłodowska Curie", BirthYear = 1867, DeathYear = 1934 },
            new FamousPeople() { Name = "Katherine Johnson", BirthYear = 1918, DeathYear = 2020 },
            new FamousPeople() { Name = "Jane C. Wright", BirthYear = 1919, DeathYear = 2013 },
            new FamousPeople() { Name = "Tu YouYou", BirthYear = 1930 },
            new FamousPeople() { Name = "Françoise Barré-Sinoussi", BirthYear = 1947 },
            new FamousPeople() { Name = "Lydia Villa-Komaroff", BirthYear = 1947 },
            new FamousPeople() { Name = "Mae C. Jemison", BirthYear = 1956 },
            new FamousPeople() { Name = "Stephen Hawking", BirthYear = 1942, DeathYear = 2018 },
            new FamousPeople() { Name = "Tim Berners-Lee", BirthYear = 1955 },
            new FamousPeople() { Name = "Terence Tao", BirthYear = 1975 },
            new FamousPeople() { Name = "Florence Nightingale", BirthYear = 1820, DeathYear = 1910 },
            new FamousPeople() { Name = "George Washington Carver", DeathYear = 1943 },
            new FamousPeople() { Name = "Frances Allen", BirthYear = 1932, DeathYear = 2020 },
            new FamousPeople() { Name = "Bill Gates", BirthYear = 1955 }
        };

        static void Main(string[] args)
        {
            // LINQ Query Syntax to retrieve people with birthdates after 1900
            var peopleAfter1900 = from person in stemPeople
                                where person.BirthYear.HasValue && person.BirthYear.Value > 1900
                                select person;
            Console.WriteLine("People with birthdates after 1900:\n");
            foreach (var person in peopleAfter1900)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine();
            Console.WriteLine();
            // Retrieve people who have two lowercase L's in their name
            var peopleWithTwoLowercaseL = from person in stemPeople
                               where person.Name.Count(c => c == 'l') == 2
                               select person;
            Console.WriteLine("People with exactly two lowercase 'l's in their name:\n");
            foreach (var person in peopleWithTwoLowercaseL)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine();
            Console.WriteLine();
            // Count the number of people with birthdays after 1950
            var peopleWithBirthdaysAfter1950 = (from person in stemPeople
                                            where person.BirthYear.HasValue && person.BirthYear.Value > 1950
                                            select person).Count();
            Console.WriteLine($"Number of people with birthdays after 1950: {peopleWithBirthdaysAfter1950}");

            Console.WriteLine();
            Console.WriteLine();
            // Retrieve people with birth years between 1920 and 2000
            // Display their names and count the number of people in the list, then display the count
            var peopleWithBirthYearsBetween1920And2000 = from person in stemPeople
                                                        where person.BirthYear.HasValue && person.BirthYear.Value>=1920 && person.BirthYear.Value<=2000
                                                        select person;
            Console.WriteLine("People with birth years between 1920 and 2000:\n");
            // Display each person's name
            foreach (var person in peopleWithBirthYearsBetween1920And2000)
            {
                Console.WriteLine(person.Name);
            }
            // Count the number of people in the resulting list
            int count = peopleWithBirthYearsBetween1920And2000.Count();
            Console.WriteLine($"\nTotal number of people: {count}");

            Console.WriteLine();
            Console.WriteLine();
            //Sort the list by BirthYear
            var sortByBirthYear = from person in stemPeople
                                orderby person.BirthYear
                                select person;
            Console.WriteLine("List of famous people sorted by BirthYear:\n");
            foreach (var person in sortByBirthYear)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine();
            Console.WriteLine();
            // Retrieve people with a death year after 1960 and before 2015, sort the list by name in ascending order
            var peopleWithDeathYearAfter1960AndBefore2015 = from person in stemPeople
                                                        where person.DeathYear.HasValue
                                                        && person.DeathYear>1960
                                                        && person.DeathYear<2015
                                                        orderby person.Name ascending
                                                        select person;

            Console.WriteLine("People with a death year after 1960 and before 2015, sorted by name:\n");
            foreach (var person in peopleWithDeathYearAfter1960AndBefore2015)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
