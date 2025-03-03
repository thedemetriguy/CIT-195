using System;
using System.ComponentModel.DataAnnotations;

namespace PetOwnerContainmentExample
{
    class Auditor
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
    class Business
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public Auditor Auditor { get; set; }

        public void DisplayBusiness()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Business Information");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Address: " + Address);
            Console.WriteLine("Auditor Information");
            Console.WriteLine("Name: " + Auditor.Name);
            Console.WriteLine("Phone: " + Auditor.Phone);
            Console.ResetColor();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Auditor Business Containment Example");
            // Creating a auditor object
            Auditor auditor = new Auditor
            {
                Name = "Dmitry",
                Phone = "2702897890"
            };
            // adding the auditor object to the business class
            Business business = new Business
            {
                Name = "Dmitry's Audits",
                Type = "Corporation",
                Address = "555 Oceana Blvd, Traverse City, MI 49686",
                Auditor = auditor
            };
            business.DisplayBusiness();
        }
    }
}
