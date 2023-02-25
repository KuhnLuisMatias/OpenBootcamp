using OpenBootcamp.Models.DataModels;

namespace OpenBootcamp.Services
{
    public class CategoryService : ICategoryService
    {

        public IEnumerable<Course> GetCourseByCategory(int categoryID)
        {
            return new List<Course>() { new Course() { CreateAt = DateTime.Now} };
        }
    }
}
