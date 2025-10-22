using System;

namespace UniversityManagementSystem
{
    class Person
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string Email;
        public string Id;

        public Person(string firstName, string lastName, int age, string email, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Email = email;
            this.Id = id;
        }

       
        public string GetFullName()
        {
            string fullName = this.FirstName + " " + this.LastName;
            return fullName;
        }

       
        public void ShowBasicInfo()
        {
            Console.WriteLine("Ad Soyad: " + GetFullName());
            Console.WriteLine("Yaş: " + this.Age);
            Console.WriteLine("Email: " + this.Email);
            Console.WriteLine("ID: " + this.Id);
        }
    }
}
