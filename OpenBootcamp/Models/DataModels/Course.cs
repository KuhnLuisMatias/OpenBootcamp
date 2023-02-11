using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace OpenBootcamp.Models.DataModels
{
    public class Course : BaseEntity
    {
        [Required]
        public Chapter index { get; set; } = new Chapter();

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(280)]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }

        public Level Level { get; set; } = Level.Basic;

        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();
        
    }
}

