using dotnet5sample.Shared;
using System.Threading.Tasks;


namespace dotnet5sample.Library
{
    public interface IPostService
    {
         Task<int> Count();
         Task<PostDto[]> GetAll();
         Task<PostDto[]> Get(int skip,int take);
    }
}