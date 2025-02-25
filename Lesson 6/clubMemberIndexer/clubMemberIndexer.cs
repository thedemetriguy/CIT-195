using System;
using System.Security.Cryptography.X509Certificates;
namespace clubMemberIndexer
{
    class Program
    {
        public const int Size = 15;  // global variable
        class ClubMembers
        {
            private string[] Members = new string[Size];
            public string ClubType { get; set; }
            public string ClubLocation { get; set; }
            public string MeetingDate { get; set; }
            
            // constructor
            public ClubMembers()
            {
                for (int i = 0; i < Size; i++)
                {
                    Members[i] = string.Empty;
                }
                ClubType= string.Empty;
                ClubLocation= string.Empty;
                MeetingDate= string.Empty;
            }

            //indexer get and set methods
            public string this[int index]
            {
                get
                {
                    string tmp;

                    if (index >= 0 && index <= Size - 1)
                    {
                        tmp = Members[index];
                    }
                    else
                    {
                        tmp = "";
                    }

                    return (tmp);
                }
                set
                {
                    if (index >= 0 && index <= Size - 1)
                    {
                        Members[index] = value;
                    }
                }

            }
        }
        static void Main(string[] args)
        {
            ClubMembers member = new ClubMembers();
            bool end = false;
            while (!end)
            {
                int sub=0;
                while (sub < 1 || sub > Size)
                {
                    Console.WriteLine($"Which club member do you want to enter (enter 1-{Size})?");
                    while (!int.TryParse(Console.ReadLine(), out sub))
                        Console.WriteLine($"Enter a value between 1-{Size}");
                }
                Console.WriteLine("Enter the name of the club member");
                member[sub-1] = Console.ReadLine();
                Console.WriteLine("Press any key to continue, q to stop");
                string stop = Console.ReadLine();
                if (stop =="q")
                    end=true;                
            }
            Console.WriteLine("What is the club's type?");
            member.ClubType = Console.ReadLine();
            Console.WriteLine("Where is the club located?");
            member.ClubLocation = Console.ReadLine();
            Console.WriteLine("When does the club meet?");
            member.MeetingDate = Console.ReadLine();

            Console.WriteLine($"Here is information on the club");
            Console.WriteLine($"Club Members");
            for (int i = 0; i < Size; i++)
            {
                if (member[i] != string.Empty) 
                    Console.WriteLine(member[i]);
            }
            Console.WriteLine($"Type: {member.ClubType}");
            Console.WriteLine($"Location: {member.ClubLocation}");
            Console.WriteLine($"Meeting Date: {member.MeetingDate}");
        }
    }
}