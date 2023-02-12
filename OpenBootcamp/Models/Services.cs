using OpenBootcamp.Models.DataModels;
using System.Linq;

namespace OpenBootcamp.Models
{
    public class Services
    {
        public static void SearchUserByEmail()
        {
            List<User> users = new List<User>
            {
                new User{
                    Name="Matias",
                    LastName="Juarez",
                    Email="matias@empresa.com",
                    Password= "1234"
                },
                new User
                {
                    Name = "Barbara",
                    LastName = "Ramirez",
                    Email = "barbara@empresa.com",
                    Password = "1234"
                },
                new User
                {
                    Name = "Sofia",
                    LastName = "Martinez",
                    Email = "sofia@enterprise.com",
                    Password = "1234"
                }
            };

            var listUsers = from user in users
                            where user.Email.Contains("@empresa.com")
                            select user;
        }
        public static void AdultStudents()
        {
            var firstCourse = new Course
            {
                Index = new Chapter() { CourseId = 1, course = new Course() },
                Name = "Ingles",
                ShortDescription = "Short Description",
                Description = "Description",
                Level = Level.Basic,
            };

            var firstStudent = new Student
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 18
            };

            firstStudent.Courses.Add(firstCourse);
            firstCourse.Categories.Add(new Category { Name = "Category 1", Courses = new List<Course>() { firstCourse } });
            firstCourse.Students.Add(firstStudent);

            List<Student> students = new List<Student> { firstStudent };
            List<Course> courses = new List<Course> { firstCourse };

            var adults = from student in students
                         where student.Age >= 18
                         select student;

            var almostOneCourse = from student in students
                                  where student.Courses.Count >= 1
                                  select student;

            var almostOneStudent = from course in courses
                                   where course.Level == Level.Basic
                                   && course.Students.Count >= 1
                                   select course;
            
            var courseCategory = from course in courses
                                 from categorie in course.Categories
                                 where course.Level == Level.Basic
                                 && categorie.Name== "Category 1"
                                 select course;

            var courseWithoutStudents = from course in courses
                                        where course.Students.Count == 0
                                        select course;

        }
    }
}
