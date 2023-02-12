
using System;
using System.Collections.Generic;

namespace OpenBootcamp_LINQ
{
    public class Student
    {
        public string FirstName { get; set; }
        
        public int Age { get; set; }

        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
