using System.ComponentModel.DataAnnotations;

namespace dotnet5sample.Shared
{
    public class PostDto{
        [Required]
        public int Id {get;set;}
        [Required]
        public string Title {get;set;}
        [Required]
        public string Body {get;set;}
        public  TagPostDto[] Tags {get;set;}
    }
}