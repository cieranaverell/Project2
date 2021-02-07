using System;
using Xunit;
using System.Collections.Generic;

using SMS.Data1.Services;
using SMS.Data1.Models;

namespace SMS.Test
{
    public class StudentServiceTest
    {
        private readonly IStudentService svc;

        public StudentServiceTest()
        {
            // general arrangement
            svc = new StudentServiceList();

            // ensure data source is empty before each test
            svc.Initialise();
        }

        [Fact]
        public void GetStudentByEmail_WhenStudentExists_ShouldReturnStudent()
        {
            //arrange

            //act
            var s = svc.AddStudent("XXX", "Computing", "xxx@gmail", 20, 50);
            var found = svc.GetStudentByEmail("xxx@gmail");
           
            //assert
            Assert.Equal("xxx@gmail", found.Email);
        }

        [Fact] // --- AddStudent Duplicate Test
        public void AddStudent_WhenDuplicateEmail_ShouldReturnNull()
        {
            // act. create two students. Same email address. 
           var s1 = svc.AddStudent("XXX", "Computing", "xxx@gmail.com", 20, 50);
           var s2 = svc.AddStudent("YYY", "Computing", "xxx@gmail.com", 19, 50);

            // assert. 
            Assert.NotNull(s1); //s1 should not be null
            Assert.Null(s2); //s2 should be null as this students should not be created
            
        }

        [Fact]
        public void AddStudent_WhenNone_ShouldSetAllProperties()
        {
            // act 
            var o = svc.AddStudent("XXX", "Computing", "xxx@email.com", 20, 0);
            // retrieve student saved 
            var s = svc.GetStudent(o.Id);

            // assert - that student is not null
            Assert.NotNull(s);
           
            // now assert that the properties were set properly
            Assert.Equal(s.Id, s.Id);
            Assert.Equal("XXX", s.Name);
            Assert.Equal("xxx@email.com", s.Email);
            Assert.Equal("Computing", s.Course);
            Assert.Equal(20, s.Age);
            Assert.Equal(0, s.Grade);
        }

        [Fact]
        public void UpdateStudent_ThatExists_ShouldSetAllProperties()
        {
            // arrange - create test student
            var o = svc.AddStudent("ZZZ", "zzz@email.com",  "Maths", 30, 100);
                       
            // act - update test student         
            o.Name = "XXX"; 
            o.Email = "xxx@email.com";         
            o.Course = "Computing";
            o.Age = o.Age = 31;
            o.Grade = 50; 
       
            o = svc.UpdateStudent(o);           
            // assert
            Assert.NotNull(o);           

            // now assert that the properties were set properly           
            Assert.Equal("XXX", o.Name);
            Assert.Equal("xxx@email.com", o.Email);
            Assert.Equal("Computing", o.Course);
            Assert.Equal(31, o.Age);
            Assert.Equal(50, o.Grade);
        }

        [Fact] 
        public void GetAllStudents_WhenNone_ShouldReturn0()
        {
            // act 
            IList<Student> students = svc.GetStudents();
            var count = students.Count;

            // assert
            Assert.Equal(0, count);            
        }


        [Fact]
        public void GetStudents_With2Added_ShouldReturn2()
        {
            // arrange
            var s1 = svc.AddStudent("XXX", "Computing",   "xxx@email.com", 20, 0);
            var s2 = svc.AddStudent("YYY", "Engineering", "yyy@email.com", 23, 0);

            // act
            var students = svc.GetStudents();
            var count = students.Count;

            // assert
            Assert.Equal(2, count);
        }


        [Fact] 
        public void GetStudent_WhenNone_ShouldReturnNull()
        {
            // act 
            var student = svc.GetStudent(1); // non existent student

            // assert
            Assert.Null(student);
        }

        [Fact] 
        public void GetStudent_WhenAdded_ShouldReturnStudent()
        {
            // act 
            var s = svc.AddStudent("XXX", "Computing", "xxx@email.com", 20, 0);

            var ns = svc.GetStudent(s.Id);

            // assert
            Assert.NotNull(ns);
            Assert.Equal(s.Id, ns.Id);
        }


        [Fact]
        public void DeleteStudent_ThatExists_ShouldReturnTrue()
        {
            // act 
            var s = svc.AddStudent("XXX", "Computing", "xxx@email.com", 20, 0);
            var deleted = svc.DeleteStudent(s.Id);

            // try to retrieve deleted student
            var s1 = svc.GetStudent(s.Id);

            // assert
            Assert.True(deleted); // delete student should return true
            Assert.Null(s1);      // s1 should be null
        }


        [Fact]
        public void DeleteStudent_ThatDoesntExist_ShouldReturnFalse()
        {
            // act 	
            var deleted = svc.DeleteStudent(0);

            // assert
            Assert.False(deleted);
        }        

        [Fact]
        public void UpdateStudent_ExistingStudentWithAgePlusOne_ShouldWork()
        {
            // arrange
            var s = svc.AddStudent("Clare", "Computing", "clare@gmail.com", 21, 0);

            // act
            s.Age = s.Age + 1;
            svc.UpdateStudent(s);
            var su = svc.GetStudent(s.Id);

            // assert
            Assert.Equal(s.Age, su.Age);
        }
        
    }
}
