using System;
using System.Globalization;

namespace StudentFileSystem
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }

        public Student(int id, string name, string surname, int age, double grade)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Grade = grade;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[{Id}] {Name} {Surname} - Yaş: {Age}, Qiymət: {Grade}");
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2},{3},{4}", Id, Name, Surname, Age, Grade);
        }
    }
}
