using OpenBootcamp.Models.DataModels;

namespace OpenBootcamp.Services
{
    public interface IChapterService
    {
        Chapter GetChapter(int courseID);
    }
}
