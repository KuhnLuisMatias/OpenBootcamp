﻿using OpenBootcamp.Models.DataModels;

namespace OpenBootcamp.Services
{
    public class StudentService : IStudentService
    {
        public IEnumerable<Course> GetCoursesByStudent(int studentID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsWithCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsWithNoCourses()
        {
            throw new NotImplementedException();
        }
    }
}
