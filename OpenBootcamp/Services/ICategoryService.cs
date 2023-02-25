using OpenBootcamp.Models.DataModels;

namespace OpenBootcamp.Services
{
    public interface ICategoryService
    {
        IEnumerable<Course> GetCourseByCategory(int categoryID);
    }
}
