
using System.Collections.Generic;

namespace OpenBootcamp_LINQ
{
    public class Course
    {
        public Chapter Index { get; set; } = new Chapter();

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public Level Level { get; set; } = Level.Basic;

        public ICollection<Category> Categories { get; set; } = new List<Category>();

        public ICollection<Student> Students { get; set; } = new List<Student>();
        
    }
}

