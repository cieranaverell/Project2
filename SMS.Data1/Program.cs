using System;
using SMS.Data1.Models;
using SMS.Data1.Services;
using System.Linq;

namespace SMS.Data1
{
    class Program
    {
        

        // OPTIONAL Q7
        public static void Main (string[] args)
        {
            // call relevant methods here to test
            Question7_1();
            Question7_2();
            Question7_3();
        }
        
        public static void Question7_1()
        {
            Console.WriteLine("\nQuestion 7.1 - List all Student Names");
            //create an instance of our service
            IStudentService svc = new StudentServiceList();
            //calls method called seed and passes this service as a parameter
            Seed(svc); // add seed data

            //after calling the seed method this list now has 4 students

            // retrieve all students and print student names
            //retrieve students
            var names = svc.GetStudents()//gets list of students
                              .Select(s => s.Name);//gets the name from student list
            //print out student names
            foreach(var n in names)
            {
                Console.WriteLine(n);
            }

            //Console.WriteLine(simpsons.ToString());//will print out all the student details
           

            
        }

        public static void Question7_2()
        {
            Console.WriteLine("\nQuestion 7.2 - List students in Grade Order");
            //create an instance of our service
            IStudentService svc = new StudentServiceList();
            Seed(svc); // add seed data

            // retrieve all students - order by grade ascending 
            // and print students name course and grade
            var simpsons = svc.GetStudents()
                            .OrderBy(s => s.Grade);
                           // .Select(s => new {s.Name, s.Course, s.Grade});
            //simpsons is now a list of anonomous objects with a name a course and a grade.
            //print list
           // Console.WriteLine(simpsons);
           foreach(var s in simpsons)
           {
               Console.WriteLine($"{s.Name} {s.Course} {s.Grade}");
           }


        }
        public static void Question7_3()
        {
            Console.WriteLine("\nQuestion 7.3 - List Students with grade >= 60");
            IStudentService svc = new StudentServiceList();
            Seed(svc); // add seed data

            // retrieve all students then print any students with a
            // grade >= 60 (marge/lisa)
            var commendations = svc.GetStudents().Where(s => s.Grade >= 60);
            foreach(var s in commendations)
           {
               Console.WriteLine($"{s.Name} {s.Course} {s.Grade}");
           }
            

        }
        
        // ===== Utility add dummy student data via service ====== 
        //seed method takes the service as a parameter and then calls the add
        //student method on our service to add these students.
        //This means the student service will now be populated with data.
        private static void Seed(IStudentService svc)
        {            
            svc.AddStudent("Homer", "Physics", "joe@mail.com", 42, 50);
            svc.AddStudent("Marge", "English", "marge@mail.com", 38, 67);
            svc.AddStudent("Lisa", "Maths", "lisa@mail.com", 14, 80);
            svc.AddStudent("Bart", "Computing", "bart@mail.com", 12, 56);
        }

    }
}
