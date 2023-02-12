using System.Collections.Generic;

namespace OpenBootcamp_LINQ
{
    public class Category
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
