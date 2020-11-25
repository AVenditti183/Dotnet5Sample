using System;
using System.Collections.Generic;

namespace Server.DataModel
{
    public  class SeedDb
    {
        private readonly MyDb context;
        public SeedDb(MyDb context)
        {
            this.context = context;
        }
        public  void SeedData()
        {
            Console.WriteLine("SeedData");

            var posts = new List<Post>();

            for (int i = 1; i < 200; i++)
            {
            posts.Add(new Post{
                Title =$"Titolo {i}",
                Body=$"Body {i}",
                Tags = new List<Tag>()
                {
                    new Tag{
                       Name ="Fico"
                    }
                }
            });
            }
            context.AddRange(posts);
            context.SaveChanges();
        }
    }
}