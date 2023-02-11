using Microsoft.EntityFrameworkCore;
using OpenBootcamp.Models.DataModels;

namespace OpenBootcamp.DataAccess
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
        {

        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Chapter> Courses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OpenBootcamp.Models.DataModels.Course> Course { get; set; }
    }
}
