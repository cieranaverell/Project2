using System.Linq;
using System.Collections.Generic;
using SMS.Data1.Models;

namespace SMS.Data1.Services{


    // Implementation of IStudentservice using a List
    //This student service list implements IStudentService
    public class StudentServiceList : IStudentService
    {
        private readonly List<Student> Students;

        public StudentServiceList()
        {
            Students = new List<Student>();
        }

        public void Initialise()
        {
            Students.Clear(); // wipe all students fom list
        }

        // ------- Student Related Operations -------

        // retrieve list of Students
        public IList<Student> GetStudents()
        {
            return Students;
        }


        // Retrive student by Id 
        public Student GetStudent(int id)
        {
            return Students.FirstOrDefault(s => s.Id == id);
        }

        // Q1 Implement GetStudentByEmail interface method here
        // Retrieve student by email

        public Student GetStudentByEmail(string email)
        {
            return Students.FirstOrDefault( s => s.Email.ToLower() == email.ToLower());
        }


        // Q2 Add a new student checking a student with same email does not exist
       public Student AddStudent(string name, string course, string email, int age, double grade)
       {
            //if duplicate  email, dont add student and return null 
            // otherwise add student and return new student
            var exists = GetStudentByEmail(email);
            if (exists != null)
            {
                return null;
            }
         
            // go ahead and create unique student
            var s = new Student{
                Id = Students.Count + 1,
                Name = name,
                Email = email,
                Course = course,
                Age = age,
                Grade = grade
            };
            Students.Add(s);
            return s; //return newly added student
        }

        // Q3 Delete the student identified by Id returning true if deleted and false if not found
        public bool DeleteStudent(int id)
        {
            // if student doesnt exist return false
            var s = GetStudent(id);
            if (s == null ) {
                return false;
            }

            var deleted = Students.RemoveAll(student => student.Id == id);
            // otherwise remove student and return true
            return deleted == 1;
        }

        // Q4 Update the student with the details in updated 
        public Student UpdateStudent(Student updated)
        {
            // retrieve student if doesnt exist return null
            var student = GetStudent(updated.Id);
            if (student == null)
            {
                return null;
            }
            // update the details of the student retrieved and return updated student
            student.Name = updated.Name;
            student.Email = updated.Email;
            student.Age = updated.Age;
            student.Course = updated.Course;
            student.Grade = updated.Grade;

            // return updated student
            return student; 
       }

    }
}