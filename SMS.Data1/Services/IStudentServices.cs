using System;
using System.Collections.Generic;
using SMS.Data1.Services;

using SMS.Data1.Models;

//Git test comment

namespace SMS.Data1.Services
{
    // This interface describes the operations that a StudentService class should implement
    public interface IStudentService
    {
        // Initialise the repository - only to be used during development 
        void Initialise();
       
        // ---------------- Student Management --------------
        IList<Student> GetStudents();
        Student GetStudent(int id);
        Student AddStudent(string name, string course, string email, int age, double grade);
        Student UpdateStudent(Student updated);  
        bool DeleteStudent(int id);

        // Q1 add GetStudentByEmail method signature here
        Student GetStudentByEmail(string email);

    }
    
}