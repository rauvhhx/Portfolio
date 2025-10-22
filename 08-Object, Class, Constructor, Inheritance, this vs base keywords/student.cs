using System;

namespace UniversityManagementSystem
{
    class Student : Person
    {
        public string StudentNumber;
        public string Faculty;
        public double GPA;
        public int Year;

        public Student(string firstName, string lastName, int age, string email, string id,
                       string studentNumber, string faculty, double gpa, int year)
            : base(firstName, lastName, age, email, id)
        {
            this.StudentNumber = studentNumber;
            this.Faculty = faculty;
            this.GPA = gpa;
            this.Year = year;
        }

        public void ShowStudentInfo()
        {
            ShowBasicInfo();
            Console.WriteLine("Tələbə nömrəsi: " + this.StudentNumber);
            Console.WriteLine("Fakültə: " + this.Faculty);
            Console.WriteLine("Kurs: " + this.Year);
            Console.WriteLine("Orta bal (GPA): " + this.GPA);
        }

        public double CalculateScholarship()
        {
            if (this.GPA >= 90)
                return 500;
            else if (this.GPA >= 80)
                return 350;
            else if (this.GPA >= 70)
                return 200;
            else
                return 0;
        }
    }
}
