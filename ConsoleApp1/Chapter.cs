
namespace OpenBootcamp_LINQ
{
    public class Chapter
    {
        public int CourseId { get; set; }
        public virtual Course course { get; set; } 
        public string List = string.Empty;
    }
}
