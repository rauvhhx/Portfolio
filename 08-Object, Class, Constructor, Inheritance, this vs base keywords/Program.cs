using System;

namespace UniversityManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            
            public Student s1 = new Student("Elvin", "Mammadov", 20, "elvin@mail.com", "S001", "2021001", "Kompüter Elmləri", 88.5, 2);
            Student s2 = new Student("Aysel", "Aliyeva", 21, "aysel@mail.com", "S002", "2021002", "İqtisadiyyat", 92.0, 3);
            Student s3 = new Student("Rauf", "Huseynli", 19, "rauf@mail.com", "S003", "2021003", "Hüquq", 68.5, 1);

            // 2 Müəllim
            Teacher t1 = new Teacher("Nigar", "Quliyeva", 35, "nigar@mail.com", "T001", "Kompüter Elmləri", "Proqramlaşdırma", 800, 15);
            Teacher t2 = new Teacher("Kamran", "Haciyev", 40, "kamran@mail.com", "T002", "İqtisadiyyat", "Mikroiqtisadiyyat", 900, 8);

            // 1 Administrator
            Administrator admin = new Administrator("Leyla", "Suleymanova", 45, "leyla@mail.com", "A001", "Dekan", "Kompüter Elmləri", 5);

            // =========================
            Console.WriteLine("=== Tələbələr ===\n");

            s1.ShowStudentInfo();
            Console.WriteLine("Təqaüd: " + s1.CalculateScholarship() + " AZN\n");

            s2.ShowStudentInfo();
            Console.WriteLine("Təqaüd: " + s2.CalculateScholarship() + " AZN\n");

            s3.ShowStudentInfo();
            Console.WriteLine("Təqaüd: " + s3.CalculateScholarship() + " AZN\n");

            // =========================
            Console.WriteLine("=== Müəllimlər ===\n");

            t1.ShowTeacherInfo();
            Console.WriteLine("Maaş: " + t1.CalculateSalary() + " AZN\n");

            t2.ShowTeacherInfo();
            Console.WriteLine("Maaş: " + t2.CalculateSalary() + " AZN\n");

            // =========================
            Console.WriteLine("=== Administrator ===\n");
            admin.ShowAdminInfo();
            admin.GrantAccess(s1);

            // =========================
            double totalScholarship = s1.CalculateScholarship() + s2.CalculateScholarship() + s3.CalculateScholarship();
            decimal totalSalary = t1.CalculateSalary() + t2.CalculateSalary();

            Console.WriteLine("\nÜmumi təqaüd xərci: " + totalScholarship + " AZN");
            Console.WriteLine("Ümumi maaş xərci: " + totalSalary + " AZN");
        }
    }
}
