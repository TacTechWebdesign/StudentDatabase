using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace StudentDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new Context())
            {
                Console.Write("Enter a StudentID for a new Student: ");
                var StudentID = Console.ReadLine();

                Console.Write("Enter the Student name: ");
                var StudentName = Console.ReadLine();

                Console.Write("Enter the Email of the Student: ");
                var EmailAddress = Console.ReadLine();

                Console.Write("Enter the Age of the Student: ");
                var Age = Console.ReadLine();

                var Student = new Student { StudentID = StudentID, StudentName = StudentName, EmailAddress = EmailAddress, Age = Age };

                Console.WriteLine(Student.StudentID + " " + Student.StudentName + " " + Student.EmailAddress);

                Console.WriteLine("Submitted");

                ctx.Students.Add(Student);
                ctx.SaveChanges();

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}

public class Student
{
    public string StudentID { get; set; }
    public string StudentName { get; set; }
    public string EmailAddress{ get; set; }
    public string Age { get; set; }
}

public class Context : DbContext
{
    public DbSet<Student> Students { get; set; }
}
