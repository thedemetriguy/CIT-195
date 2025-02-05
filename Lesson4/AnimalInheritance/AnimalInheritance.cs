using System;

namespace AnimalInheritance
{
    // base Class 
    class Animal
    {
        private string name; // only accessible within this class
        protected string type; //accessible from derived classes
        public string color;  // accessible from any class

        public void setName(string name)
        {
            this.name = name;
        }
        public virtual string getName() 
        { 
            return this.name; 
        }
        public void setType(string type) 
        { 
            this.type = type; 
        }
        public virtual string getType() 
        { 
            return this.type;
        }
    }

     // derived class 
    class Turtle : Animal
    {
        public string breed;  // accessible from any class
        protected int age;  //accessible from derived classes

        public void setAge(int age)
        {
            this.age = age;
        }
        public virtual int getAge()
        {
            return age;
        }

        // access name through base because it is private
        public override string getName()
        {
            return base.getName();
        }

        // access type directly because it is protected and this is a derived class
        public override string getType()
        {
            return type;
        }

        public virtual string sound()
        {
            return "scream a lot";
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            // object of the base class Animal
            Animal dog = new Animal();
            dog.setName("Maggy");
            dog.setType("Golden retriever");
            // color is a public field and can be accessed anywhere
            dog.color = "brown";

            Console.WriteLine("Dog Information...");
            Console.WriteLine($"My name is {dog.getName()}");
            Console.WriteLine($"I am a {dog.getType()}");
            Console.WriteLine($"I am a lovely {dog.color} color");
            Console.WriteLine();

            // object of derived class Dog
            Turtle myTurtle = new Turtle();
            myTurtle.setName("Nathan");
            myTurtle.setType("Pond slider");
            // color is a public field and can be accessed anywhere
            myTurtle.color = "Gray";
            // breed is a public field
            myTurtle.breed = "Snapping turtle";
            // age is a protected field
            myTurtle.setAge(100);

            Console.WriteLine("Turtle Information...");
            Console.WriteLine($"My name is {myTurtle.getName()}");
            Console.WriteLine($"I am a {myTurtle.breed} {myTurtle.getType()}");
            Console.WriteLine($"I am a lovely {myTurtle.color} color");
            Console.WriteLine($"I am {myTurtle.getAge()} years old");
            Console.WriteLine($"I like to {myTurtle.sound()}");

            Console.ReadLine(); // pauses end of program display
        }

    }
}