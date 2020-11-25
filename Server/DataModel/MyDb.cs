using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Server.DataModel
{
    public class MyDb : DbContext
    {
        public MyDb(DbContextOptions<MyDb> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region initial value
            var posts = new List<Post>();

            for (int i = 1; i < 200; i++)
            {
            posts.Add(new Post{
                Id=i,
                Title =$"Titolo {i}",
                Body=$"Body {i}"
            });
            }

            modelBuilder.Entity<Post>().HasData(posts);

            #endregion

        }
    }
}