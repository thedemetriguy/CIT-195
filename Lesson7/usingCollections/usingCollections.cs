using System;
using System.Collections.Generic;

namespace Chapter7Ex1MultipleCollections
{
    class Program
    {
        static void UseQueue()
        {
            // Creates the members queue
            Queue < string > members = new Queue < string >();
            
            //adding members
            members.Enqueue("Dmitry");
            members.Enqueue("Sacha");
            members.Enqueue("Micha");
            members.Enqueue("Killian");
            members.Enqueue("Gavin");

            //checking if a member is in the queue
            Console.Write("Enter a member name: ");
            string member = Console.ReadLine ();
            if (members.Contains(member))
            {
                Console.WriteLine($"{member} is in the Queue");
            }
            else
            {
                Console.WriteLine($"{member} is NOT in the Queue");
            }

            // adding more members
            Console.WriteLine("How many members would you like to add?");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Member name: ");
                members.Enqueue(Console.ReadLine());
            }

            // counts the members in the queue
            Console.WriteLine($"Here are your {members.Count()} members");
            // displays the queue contents without removing anything
            foreach (var m in members)
            {
                Console.WriteLine(m);
            }

           // views the first item in the queue and displays it to determine if the user wants to remove it
            string firstMem = members.Peek();
            Console.WriteLine($"Would you like to remove {firstMem} from the beginning of the queue (yes or no)?");
            string answer = Console.ReadLine();
            while (answer=="yes")
            {
                members.Dequeue(); // removes item from the top of the queue
                firstMem= members.Peek();
                Console.WriteLine($"Would you like to remove {firstMem} from the beginning of the queue (yes or no)?");
                answer = Console.ReadLine();
            }
           
            if (members.Peek() == null)
                Console.WriteLine("The queue is empty");
            else
                Console.WriteLine($"You have {members.Count} left in the queue");

        }

        static void UseStack()
        {
            // Creates the members Stack
            Stack < string > members = new Stack < string >();
            //adding members
            members.Push("Dmitry");
            members.Push("Sacha");
            members.Push("Micha");
            members.Push("Landon");
            members.Push("Harper");
            // adding more members
            Console.WriteLine("How many members would you like to add?");
            int num = int.Parse(Console.ReadLine());
            // adds data to the members Stack
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Member name: ");
                members.Push(Console.ReadLine());
            }
            // Check for an item in the Stack
            Console.WriteLine("Would you like to look for a member (yes or no)");
            string answer = Console.ReadLine();
            while(answer == "yes")
            {
                Console.WriteLine("Enter the name of the member you would like to search for");
                string memberName = Console.ReadLine();
                if(members.Contains(memberName))
                {
                    Console.WriteLine("That member is part of the group.");
                }
                else
                {
                    Console.WriteLine("I am sorry, that person is not part of the group");
                }
                Console.WriteLine("Would you like to look for another member (yes or no)");
                answer = Console.ReadLine();
            }
            // counts the members in the Stack
            Console.WriteLine($"Here are your {members.Count()} members");
            // displays the Stack contents without removing anything
            foreach (var m in members)
            {
                Console.WriteLine(m);
            }
            string firstMem = members.Peek();   // retrieves the LAST item
            Console.WriteLine($"Would you like to remove {firstMem} from the end of the Stack (yes or no)?");
            answer = Console.ReadLine();
            while (answer == "yes")
            {
                members.Pop();  // Removes the LAST item
                firstMem = members.Peek();
                Console.WriteLine($"Would you like to remove {firstMem} from the end of the Stack (yes or no)?");
                answer = Console.ReadLine();
            }

            if (members.Peek() == null)
                Console.WriteLine("The Stack is empty");
            else
                Console.WriteLine($"You have {members.Count} left in the Stack");

        }
        static void UseLinkdedList()
        {
            // Create the friendList
            LinkedList < string > friendList = new LinkedList < string >();
            // Add initial 5 items
            friendList.AddLast("Alice");
            friendList.AddLast("Bob");
            friendList.AddLast("Charlie");
            friendList.AddLast("David");
            friendList.AddLast("Eve");
            Console.WriteLine("Original friend list");
            foreach (string friend in friendList)
            {
                Console.WriteLine(friend);
            }
            Console.WriteLine();
            // Retrieve and display the first node
            if (friendList.First != null) // Ensure the list is not empty
            {
                Console.WriteLine("First node: " + friendList.First.Value);
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }

            // Retrieve and display the last node
            if (friendList.Last != null) // Ensure the list is not empty
            {
                Console.WriteLine("Last node: " + friendList.Last.Value);
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
            // Finding the second node (Bob)
            LinkedListNode<string> node = friendList.First;
            for (int i = 0; i < 1; i++) // Move to the 2nd node
            {
                node = node.Next;
            }
            //Add a 6th item to the middle of the list
            friendList.AddAfter(node, "Drake");

            //Remove a node from the list
            if (friendList.Contains("Charlie"))
            {
                friendList.Remove("Charlie");  // Removes the first occurrence of "Charlie"
                Console.WriteLine("Charlie removed.");
            }
            else
            {
                Console.WriteLine("Charlie not found.");
            }

            //Count the items in linked list and display the count
            Console.WriteLine($"There are {friendList.Count} friends in the friendList");

            //Print all the items in the linked list
            Console.WriteLine("Members in the LinkedList:");
            foreach (string friend in friendList)
            {
                Console.WriteLine(friend);
            }
        }
        static void UseDictionary()
        {
            Dictionary< string, string > EmployeeList = new Dictionary< string, string >();
             //Adding Employees
            EmployeeList.Add("Dmitry", "Line Cook");
            EmployeeList.Add("Jo", "Dishwasher");
            EmployeeList.Add("Wesley", "Prep cook");
            EmployeeList.Add("Kyle", "Manager");
            EmployeeList.Add("Stephanie", "Bartender");
            Console.WriteLine("EmployeeList Keys");
            Dictionary < string, string >.KeyCollection keys = EmployeeList.Keys;
            foreach (string k in keys)
            {
                Console.WriteLine("Key: {0}", k);
            }
            Console.WriteLine();

            Console.WriteLine("EmployeeList Values");
            Dictionary < string, string >.ValueCollection values = EmployeeList.Values;
            foreach (string v in values)
            {
                Console.WriteLine("Value: {0}", v);
            }
            Console.WriteLine();
            Console.WriteLine("EmployeeList Key/Value Pairs");
            foreach (KeyValuePair < string,string > kvp in EmployeeList)
            {
                Console.WriteLine($"Key: {kvp.Key}  Value: {kvp.Value}");
            }
            Console.WriteLine();
            //Remove an item from the dictionary
            EmployeeList.Remove("Jo");
            //Display a count of the dictionary items
            Console.WriteLine($"There are {EmployeeList.Count} employees in your list");
        }
        static void UseHashSet()
        {
            HashSet < string > hobbies = new HashSet < string >();
            //Add 5 items to a hashset object
            hobbies.Add("Rowing");
            hobbies.Add("Weight Lifting");
            hobbies.Add("Skiing");
            hobbies.Add("Programming");
            hobbies.Add("Calistenics");
            //Create a similar hashset object with 5 items
            HashSet<string> fruits = new HashSet<string>
            {
                "Apple",
                "Banana",
                "Cherry",
                "Avocado",
                "Blueberry"
            };
            //Create a third hashset object and add 5 more items (2 items should be the same as your first or second object)
            HashSet < string > items = new HashSet < string >();
            items.Add("Calistenics");
            items.Add("Weight Lifting");
            items.Add("Math");
            items.Add("Nutrition");
            items.Add("Nature");
            //Use a command to combine the first and second object. Store the combined items in the first object
            hobbies.UnionWith(fruits);
            //Use a command to combine the first and third object. Store the combined items in the first object
            //Create a third object
            HashSet<string> seasons = new HashSet<string>
            {
                "Summer",
                "Fall",
                "Winter",
                "Spring",
            };
            hobbies.UnionWith(seasons);
            //Print out the contents of the first object
            Console.WriteLine("Hobbies in the HashSet:");
            foreach (var hobby in hobbies)
            {
                Console.WriteLine(hobby);
            }
        }
    }
}