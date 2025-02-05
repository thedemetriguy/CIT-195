using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Transactions;

namespace Inheritance
{
    // Base Class
    class Person
    {
        private int _Id;
        private string _FirstName;
        private string _LastName;

        public int Id { get => _Id; set => _Id = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string LastName { get => _LastName; set => _LastName = value; }

        public Person()
        {
            _Id = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
        }

        public Person(int id, string firstName, string lastName)
        {
            _Id = id;
            _FirstName = firstName;
            _LastName = lastName;
        }

        public virtual void addChange()
        {
            Console.Write("ID: ");
            _Id = int.Parse(Console.ReadLine());
            Console.Write("First Name: ");
            _FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            _LastName = Console.ReadLine();
        }

        public virtual void Print()
        {
            Console.WriteLine($"ID: {_Id}\nName: {_FirstName} {_LastName}");
        }
    }
    //Derived Student Class
    class Student: Person
    {
        private int _Grade;

        // default constructor
        public Student()
        {
            _Grade = 0;
        }
        //parameterized constructor
        public Student(int grade)
        {
            _Grade = grade;
        }
        // Get and Set Methods
        public int getGrade() { return _Grade; }
        public void setGrade(int grade) { _Grade = grade; }

        public override void addChange()
        {
            base.addChange();
            Console.Write("Grade=");
            setGrade(int.Parse(Console.ReadLine()));
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Grade: {getGrade()}");
        }
    }
    // Derived Teacher Class
    class Teacher : Person
    {
        private string _Type;
        private int _Experience;

        public Teacher()
            : base()
        {
            _Type = string.Empty;
            _Experience = 0;
        }
        public Teacher(int id, string firstname, string lastname, string type, int experience)
            : base(id, firstname, lastname)
        {
            _Type = type;
            _Experience = experience;
        }
        public void setType(string type) { _Type = type; }
        public void setExperience(int experience) { _Experience = experience; }
        public string getType() { return _Type; }
        public int getExperience() { return _Experience; }
        public override void addChange()
        {
            base.addChange();
            Console.Write("Type=");
            setType(Console.ReadLine());
            Console.Write("Experience =");
            setExperience(int.Parse(Console.ReadLine()));
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Type: {getType()}");
            Console.WriteLine($"Experience: {getExperience()}");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many students do you want to enter?");
            int maxStudents;
            while (!int.TryParse(Console.ReadLine(), out maxStudents))
                Console.WriteLine("Please enter a whole number");
            // array of Student objects
            Student[] students = new Student [maxStudents];

            Console.WriteLine("How many teachers do you want to enter?");
            int maxTeachers;
            while (!int.TryParse(Console.ReadLine(), out maxTeachers))
                Console.WriteLine("Please enter a whole number");
            // array of Teacher objects
            Teacher[] mgr = new Teacher[maxTeachers];

            int choice, rec, type;
            int studentCounter = 0, teacherCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Teacher or 2 for Student");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Teacher or 2 for Student");
                try
                {
                    switch (choice)
                    {
                        case 1: // Add
                            if (type == 1) //Teacher
                            {
                                if (teacherCounter < maxTeachers)
                                {
                                    mgr[teacherCounter] = new Teacher(); // places an object in the array instead of null
                                    mgr[teacherCounter].addChange();
                                    teacherCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of teachers has been added");

                            }
                            else //Student
                            {
                                if (studentCounter < maxStudents)
                                {
                                    students[studentCounter] = new Student(); // places an object in the array instead of null
                                    students[studentCounter].addChange();
                                    studentCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of students has been added");
                            }

                            break;
                        case 2: //Change
                            Console.Write("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the record number you want to change: ");
                            rec--;  // subtract 1 because array index begins at 0
                            if (type == 1) //Teacher
                            {
                                while (rec > teacherCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                mgr[rec].addChange();
                            }
                            else // Student
                            {
                                while (rec > studentCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                students[rec].addChange();
                            }
                            break;
                        case 3: // Print All
                            if (type == 1) //Teacher
                            {
                                for (int i = 0; i < teacherCounter; i++)
                                    mgr[i].Print();
                            }
                            else // Student
                            {
                                for (int i = 0; i < studentCounter; i++)
                                    students[i].Print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }


        private static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}
