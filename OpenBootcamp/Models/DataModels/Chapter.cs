using Microsoft.Build.Framework;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace OpenBootcamp.Models.DataModels
{
    public class Chapter : BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course course { get; set; } = new Course();
        [Required]
        public string List = string.Empty;
    }
}
