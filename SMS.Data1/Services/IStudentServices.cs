using System;
using System.Collections.Generic;
using SMS.Data1.Services;

using SMS.Data1.Models;


namespace SMS.Data1.Services
{
    // This interface describes the operations that a StudentService class should implement
    //interface is a specification for a class. If you want to create a class of type
    //Student interface then your class must provide these methods.
    public interface IStudentService
    {
        //These are the methods that must be provided but they are simply
        //method signatures with no body to the method.
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