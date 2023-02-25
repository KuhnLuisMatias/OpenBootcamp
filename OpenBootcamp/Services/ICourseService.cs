using OpenBootcamp.Models.DataModels;

namespace OpenBootcamp.Services
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCourseWithOutSubject();
        IEnumerable<Course> GetChapterByCourse(int courseID);
        IEnumerable<Student> GetStudentByCourse(int courseID);
    }
}
