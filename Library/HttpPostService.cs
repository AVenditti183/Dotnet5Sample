using System.Net.Http;
using dotnet5sample.Shared;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace dotnet5sample.Library
{
    public class HttpPostService : IPostService
    {
        private readonly HttpClient httpClient;

        public HttpPostService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public  Task<int> Count() =>  httpClient.GetFromJsonAsync<int>("api/post/count");
        public  Task<PostDto[]> GetAll() =>  httpClient.GetFromJsonAsync<PostDto[]>("api/post/all");
        public  Task<PostDto[]> Get(int skip, int take) =>  httpClient.GetFromJsonAsync<PostDto[]>($"api/post/part/{skip}/{take}");
    }
}