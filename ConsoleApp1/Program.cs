using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Intro;



namespace Intro
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            object p = optionsBuilder.UseSqlServer(
                    @"Data Source=FOXY;Initial Catalog=Alice;Integrated Security=True");
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new BloggingContext())
        {
            var blog = new Blog
            {
           
                Url = "google.com",
                Rating = 17
            };
            var post = new Post
            {
                Blog = blog,
                Title = "horrible evol",
                Content = "Once upon a time was a programmirovanie..."
            };
           
            context.Posts.Add(post);
            context.SaveChanges();
            
        }

        Console.WriteLine();
    }

}


