using OpenBootcamp.Models.DataModels;

namespace OpenBootcamp.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudentsWithCourses();
        IEnumerable<Student> GetStudentsWithNoCourses();
    }
}
