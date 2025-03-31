using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentProgram
{
    // Class representing a student.
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public double Tuition { get; set; }

        public override string ToString()
        {
            return $"{StudentID}: {StudentName}, Age: {Age}, Major: {Major}, Tuition: {Tuition:C}";
        }
    }

    // Class representing the clubs a student is part of.
    public class StudentClubs
    {
        public int StudentID { get; set; }
        public string ClubName { get; set; }

        public override string ToString()
        {
            return $"StudentID {StudentID} - Club: {ClubName}";
        }
    }

    // Class representing a student's GPA.
    public class StudentGPA
    {
        public int StudentID { get; set; }
        public double GPA { get; set; }

        public override string ToString()
        {
            return $"StudentID {StudentID} - GPA: {GPA:F1}";
        }
    }

    // This class is used to hold the joined data (student name, major, and GPA).
    public class StudentDetail
    {
        public string StudentName { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }

        public override string ToString()
        {
            return $"Name: {StudentName}, Major: {Major}, GPA: {GPA}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Student collection
            IList<Student> studentList = new List<Student>()
            { 
                new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major = "Hospitality", Tuition = 3500.00 },
                new Student() { StudentID = 2, StudentName = "Gina Host", Age = 21, Major = "Hospitality", Tuition = 4500.00 },
                new Student() { StudentID = 3, StudentName = "Cookie Crumb",  Age = 21, Major = "CIT", Tuition = 2500.00 },
                new Student() { StudentID = 4, StudentName = "Ima Script",  Age = 48, Major = "CIT", Tuition = 5500.00 },
                new Student() { StudentID = 5, StudentName = "Cora Coder",  Age = 35, Major = "CIT", Tuition = 1500.00 },
                new Student() { StudentID = 6, StudentName = "Ura Goodchild", Age = 40, Major = "Marketing", Tuition = 500.00 },
                new Student() { StudentID = 7, StudentName = "Take Mewith", Age = 29, Major = "Aerospace Engineering", Tuition = 5500.00 }
            };

            // Student GPA collection
            IList<StudentGPA> studentGPAList = new List<StudentGPA>()
            {
                new StudentGPA() { StudentID = 1, GPA = 4.0 },
                new StudentGPA() { StudentID = 2, GPA = 3.5 },
                new StudentGPA() { StudentID = 3, GPA = 2.0 },
                new StudentGPA() { StudentID = 4, GPA = 1.5 },
                new StudentGPA() { StudentID = 5, GPA = 4.0 },
                new StudentGPA() { StudentID = 6, GPA = 2.5 },
                new StudentGPA() { StudentID = 7, GPA = 1.0 }
            };

            // Club collection
            IList<StudentClubs> studentClubList = new List<StudentClubs>()
            {
                new StudentClubs() { StudentID = 1, ClubName = "Photography" },
                new StudentClubs() { StudentID = 1, ClubName = "Game" },
                new StudentClubs() { StudentID = 2, ClubName = "Game" },
                new StudentClubs() { StudentID = 5, ClubName = "Photography" },
                new StudentClubs() { StudentID = 6, ClubName = "Game" },
                new StudentClubs() { StudentID = 7, ClubName = "Photography" },
                new StudentClubs() { StudentID = 3, ClubName = "PTK" }
            };

            //a) Group by GPA and display the student's IDs
            var groups = studentGPAList.GroupBy(s => s.GPA);

            Console.WriteLine("Students grouped by GPA:");
            foreach (var group in groups)
            {
                Console.WriteLine($"GPA: {group.Key}");
                Console.WriteLine("Student IDs: " + string.Join(", ", group.Select(s => s.StudentID)));
                Console.WriteLine();
            }

            // b) Sort by Club, then group by Club and display the student's IDs
            var Groups = studentClubList
                         .OrderBy(sc => sc.ClubName)
                         .GroupBy(sc => sc.ClubName);

            Console.WriteLine("Student IDs grouped by Club:\n");
            foreach (var group in groups)
            {
                Console.WriteLine($"Club: {group.Key}");
                // For each group, extract the StudentIDs and join them into a comma-separated string.
                string studentIDs = string.Join(", ", group.Select(sc => sc.StudentID));
                Console.WriteLine($"Student IDs: {studentIDs}\n");
            }

            // c) Count the number of students with a GPA between 2.5 and 4.0
            int count = studentGPAList.Count(s => s.GPA >= 2.5 && s.GPA <= 4.0);
            Console.WriteLine($"Number of students with a GPA between 2.5 and 4.0: {count}");

            // d) Average all student's tuition
            double averageTuition = studentList.Average(s => s.Tuition);
            Console.WriteLine($"Average tuition of all students: {averageTuition:C}");

            // e) Find the student paying the most tuition and display their name, major and tuition. 
            // HINT: You will need to retrieve and store the highest tuition, 
            // then use a foreach loop to iterate through the studentList comparing each student's tuition to the highest. 
            // If they are equal, print out the data.
            double highestTuition = studentList.Max(s => s.Tuition);
            Console.WriteLine($"Highest Tuition: {highestTuition:C}\n");
            Console.WriteLine("Student(s) paying the highest tuition:");
            foreach (var student in studentList)
            {
                if (student.Tuition == highestTuition)
                {
                    Console.WriteLine($"Name: {student.StudentName}, Major: {student.Major}, Tuition: {student.Tuition:C}");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            // f) Join the student list and student GPA list on student ID and display the student's name, major and gpa
            var studentDetails = studentList.Join(
                studentGPAList,                    
                student => student.StudentID,        
                gpa => gpa.StudentID,               
                (student, gpa) => new StudentDetail              // Result selector: create an anonymous object.
                {
                    StudentName = student.StudentName,
                    Major = student.Major,
                    GPA = gpa.GPA
                }
            );
            Console.WriteLine("Student Details (Name, Major, GPA):\n");
            foreach (var detail in studentDetails)
            {
                Console.WriteLine(detail);
            }

            Console.WriteLine();
            Console.WriteLine();
            // g) Join the student list and student club list. Display the names of only those students who are in the Game club.
             // Join the student list and student club list on StudentID.
            var gameClubStudents = studentList.Join(
                studentClubList,                   
                student => student.StudentID,      
                club => club.StudentID,            
                (student, club) => new             // Result selector: create an anonymous object.
                {
                    student.StudentName,
                    club.ClubName
                }
            )
            // Filter for those in the "Game" club.
            .Where(sc => sc.ClubName.ToLower() == "game");

            Console.WriteLine("Students in the Game club:");
            foreach (var s in gameClubStudents)
            {
                Console.WriteLine(s.StudentName);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
