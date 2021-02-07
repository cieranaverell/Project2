using System;
using SMS.Data1.Models;
using SMS.Data1.Services;

namespace SMS.Data1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Student {Id = 1, Name = "Fred"};
            Console.WriteLine($"Hello {s}");
        }

        // OPTIONAL Q7
      //  public static void Main (string[] args)
      //  {
            // call relevant methods here to test
       //     Question7_1();
       //    Question7_2();
       //     Question7_3();
       // }
        
        public static void Question7_1()
        {
            Console.WriteLine("\nQuestion 7.1 - List all Student Names");
            IStudentService svc = new StudentServiceList();
            Seed(svc); // add seed data

            // retrieve all students and print student names
            
        }

        public static void Question7_2()
        {
            Console.WriteLine("\nQuestion 7.2 - List students in Grade Order");
            IStudentService svc = new StudentServiceList();
            Seed(svc); // add seed data

            // retrieve all students - order by grade ascending 
            // and print students name course and grade
            

        }
        public static void Question7_3()
        {
            Console.WriteLine("\nQuestion 7.3 - List Students with grade >= 60");
            IStudentService svc = new StudentServiceList();
            Seed(svc); // add seed data

            // retrieve all students then print any students with a
            // grade >= 60 (marge/lisa)
            

        }
        
        // ===== Utility add dummy student data via service ====== 
        private static void Seed(IStudentService svc)
        {            
            svc.AddStudent("Homer", "Physics", "joe@mail.com", 42, 50);
            svc.AddStudent("Marge", "English", "marge@mail.com", 38, 67);
            svc.AddStudent("Lisa", "Maths", "lisa@mail.com", 14, 80);
            svc.AddStudent("Bart", "Computing", "bart@mail.com", 12, 56);
        }

    }
}
