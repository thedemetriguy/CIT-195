using System;
namespace GenericAnimalClass
{
    public class Animal < T >
    {
        // define a property of type T 
        public T data {get; set;}

        // define a constructor of the Animal class 
        public Animal(T data)
        {
            this.data = data;
        }
        public T getAnimal()
        {
            return data;
        }
    }

    class Program
    {
        static void Main()
        {
            // create an instance with a string data type
            Animal < string > animalName = new Animal < string >("Wolf");
            Animal < string > animalHabitat = new Animal < string >("Forests, grasslands, deserts, and tundra");

            // create an instance with a boolean data type
            Animal < bool > endangered = new Animal<bool> (false);
            Animal < bool > extinct = new Animal<bool> (false);

            // create an instance with a boolean data type
            Animal < int > averageLifespan = new Animal<int> (16);

            // Printing values using getAnimal method
            Console.WriteLine("Animal Name: " + animalName.getAnimal());
            Console.WriteLine("Habitat: " + animalHabitat.getAnimal());
            Console.WriteLine("Endangered: " + endangered.getAnimal());
            Console.WriteLine("Extinct: " + extinct.getAnimal());
            Console.WriteLine("Average Lifespan: " + averageLifespan.getAnimal() + " years");
        }
    }

}