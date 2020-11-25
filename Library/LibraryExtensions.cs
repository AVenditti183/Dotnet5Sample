using System;
using Microsoft.Extensions.DependencyInjection;
using dotnet5sample.Library;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LibraryExtensions
    {
        public static void AddLibrary(this IServiceCollection service)
        {
            service.AddScoped<IPostService, HttpPostService>();
            service.AddScoped<ITagService, HttpTagService>();
        }
    }
}
