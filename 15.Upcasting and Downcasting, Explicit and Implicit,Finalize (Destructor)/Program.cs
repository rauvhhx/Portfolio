namespace _15.Upcasting_and_Downcasting__Explicit_and_Implicit_Finalize__Destructor_.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog { AvgLifeTime = 20, Breed = "Kangal", Gender = "Male", Name = "Ted" };
            Eagle eagle = new Eagle { AvgLifeTime = 300, FlySpeed = 20, Gender = "Female" };

            Animals animals = dog;
            Animals animals2 = eagle;

            Dog dog1 = (Dog)animals;

            Eagle eagle1 = (Eagle)animals2;

        }
    }
}