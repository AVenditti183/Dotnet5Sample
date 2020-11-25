using System.Collections;
using System.Collections.Generic;

namespace Server.DataModel
{
    public class Tag
    {
        public Tag()
        {
            Posts = new List<Post>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}