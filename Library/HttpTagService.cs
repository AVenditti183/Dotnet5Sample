using System.Net.Http;
using dotnet5sample.Shared;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace dotnet5sample.Library
{
    public class HttpTagService : ITagService
    {
        private readonly HttpClient httpClient;

        public HttpTagService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public  Task<TagPostDto[]> GetAll()=>  httpClient.GetFromJsonAsync<TagPostDto[]>("api/tag/all");
    }
}