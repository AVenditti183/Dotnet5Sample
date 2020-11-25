using System.Collections.Generic;

namespace Server.DataModel
{
    public class Post
    {
        public Post()
        {
            Tags = new List<Tag>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}