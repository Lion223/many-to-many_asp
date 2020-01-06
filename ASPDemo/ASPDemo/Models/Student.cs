using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDemo.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public Student()
        {
            Courses = new List<Course>();
        }
    }
}