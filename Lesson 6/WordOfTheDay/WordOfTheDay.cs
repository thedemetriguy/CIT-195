 
using System;
using System.IO;

namespace FileHandlingDemo1
{
    internal class Program
    {
        static void Main()
        {
            int choice = Menu();
            while (choice != 5)
            {
                switch (choice)
                {
                    case 1:
                        // Will create if it doesn't exist or add to existing file
                        AppendToFile();
                        break;
                    case 2:
                        ReadFile();
                        break;
                    case 3:
                        ReadToArray();
                        break;
                    case 4:
                        try
                        {
                        string path = "Words.txt";
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                            Console.WriteLine("File deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("File does not exist.");
                        }
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                        break;
                        }
                    choice = Menu();
                }

        }
        static int Menu()
        {
            Console.WriteLine("Enter your choice:\n1. Add Word\n2. Read All\n" +
                "3. Read Current Word\n4. Delete File\n5. Exit");
            int choice = 0;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 8)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 8.");
            }
            return choice;
        }
    
        static void AppendToFile()
        {
            string path = "Words.txt";

            Console.WriteLine("Word?");
            string newString = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newString))
            {
                Console.WriteLine("Enter a valid word:");
                newString = Console.ReadLine();
            }
            newString = newString + ":  ";
            bool boolean = true;
            int counter = 1;
            string definitions = "";
            do 
            {
                Console.WriteLine("Definition?");
                string temp = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(newString))
                {
                    Console.WriteLine("Enter a valid definition:");
                    temp = Console.ReadLine();
                }
                definitions += counter + ". " + temp + " ";
                Console.WriteLine("Another definition? (y/n)");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    counter++;
                }
                else
                {
                    boolean = false;
                }
            }while(boolean == true);
            newString += definitions + "\n";
            try
            {
                File.AppendAllText(path, newString);
                Console.WriteLine("The word and definition have been added successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return;
        }
        static void ReadFile()
        {
            string path = "Words.txt";
            try
            {
                if (File.Exists(path))
                {
                    string content = File.ReadAllText(path);
                    Console.WriteLine("File Content:\n" + content);
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return;

        }
        static void ReadToArray()
        {
            string path = "Words.txt";
            try
            {
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    string currentWord = lines[lines.Length - 1];
                    Console.WriteLine("File Content as Array:");
                    Console.WriteLine($"Current Word: {currentWord}");
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        
    }
}
