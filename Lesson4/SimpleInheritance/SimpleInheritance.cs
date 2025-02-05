using System;

namespace Inheritance
{

    // base class
    class Animal
    {
        public string name;
        public string type;
        public string color;

        // constructor
        public Animal()
        {
            name = "";

        }
        //parameterized constructor
        public Animal(string name, string type, string color)
        {
            this.name = name;
            this.type = type;
            this.color = color;
        }

        public void display()
        {
            Console.WriteLine($"I am an animal, my name is {name}");
        }

    }

    // derived class of Animal 
    class Cat : Animal
    {
        public double age;
        public double weight;
        public double height;

        // constructor
        public Cat()
            :base()  // calls the Animal class constructor
        {           
            age = 0; 
            weight = 0;
            height = 0;
        }
        //parameterized constructor
        public Cat(string name, string type, string color, double age, double weight, double height)
            :base(name,type,color)
        {
            this.age = age;
            this.weight = weight;
            this.height = height;
        }
        public void getName()
        {
            Console.WriteLine($"My name is {name}");
        }
        public void sound()
        {
            Console.WriteLine($"I like to meow and hiss!");
        }
        public void getColor()
        {
            Console.WriteLine($"I am {color}");
        }
        public void getAge()
        {
            Console.WriteLine($"I am {age} years old");
        }
        public void getWeight()
        {
            Console.WriteLine($"I weigh {weight} pounds");
        }
        public void getHeight()
        {
            Console.WriteLine($"I am {height} inches");
        }
    }

    class guineaPig: Animal
    {
        public double age;
        public double weight;
        public double height;

        // constructor
        public guineaPig()
            :base()  // calls the Animal class constructor
        {           
            age = 0; 
            weight = 0;
            height = 0;
        }
        //parameterized constructor
        public guineaPig(string name, string type, string color, double age, double weight, double height)
            :base(name,type,color)
        {
            this.age = age;
            this.weight = weight;
            this.height = height;
        }
        public void display ()
        {
            Console.WriteLine($"Name: {name}\nColor: {color}\nAge:{age}\nWeight:{weight}\nHeight: {height}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // object of base class
            Animal myPet = new Animal();
            myPet.name = "Michael";
            myPet.display();

            // derived class object using default constructor
            Cat myCat = new Cat();
            myCat.name = "Sarah";
            myCat.type = "Persian";
            myCat.color = "brown";
            myCat.age = 5;
            myCat.weight = 10;
            myCat.height = 15;
            myCat.getName();
            myCat.getColor();
            myCat.getAge();
            myCat.getWeight();
            myCat.getHeight();


            //derived class object using parameterized constructor
            Cat cat = new Cat("Ranger", "Russian", "white", 10, 8, 12);
            // cat.display();
            cat.getName();
            cat.getColor();
            cat.getAge();
            cat.getWeight();
            cat.getHeight();

            guineaPig myGuineaPig = new guineaPig();
            myGuineaPig.name = "Mattie";
            myGuineaPig.type = "Teddy guinea pig";
            myGuineaPig.color = "orange";
            myGuineaPig.age = 2;
            myGuineaPig.weight = 2.1;
            myGuineaPig.height = 5;
            myGuineaPig.display();

            guineaPig guineaPig = new guineaPig("Alex", "Skinny pig", "black", 1, 2.3, 5);
            guineaPig.display();
        }

    }
}