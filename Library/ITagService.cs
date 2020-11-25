using dotnet5sample.Shared;
using System.Threading.Tasks;


namespace dotnet5sample.Library
{
    public interface ITagService
    {
        Task<TagPostDto[]> GetAll();
    }
}