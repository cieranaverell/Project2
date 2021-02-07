using System;

namespace SMS.Data1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

         public string Email { get; set; }
        public string Course { get; set; }
        public int Age { get; set; } 
        public double Grade { get; set; }

         public override string ToString()
        {
            return $"(Id-{Id}-{Name}-{Age}-{Email}-{Classification})";
        }
        
         // optional question - readonly property
        public string Classification => Classify();

         // private classifier function
        private string Classify()
        {
            if (Grade < 50)
            {
                return "Fail";
            }
            else if (Grade >= 50 && Grade <= 69)
            {
                return "Pass";
            }
            else if (Grade >=70 && Grade <= 79)
            {
                return "Commendation";
            }
            else
            {
                return "Distinction";
            }
        }
     
       
    }
}