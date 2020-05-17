using System;
using System.Linq;

namespace Degree53_BlogTechTest.Data.Models
{
    public class DbInitializer
    {
        // Seed database
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // If there aren't any articles in the db, create some stock ones.
            if (!context.Articles.Any())
            {
                context.AddRange
                (
                    new ArticleModel
                    {
                        Title = "Wow this is an article!",
                        Content = "This is some content.",
                        DateTimePosted = DateTime.UtcNow,
                        OwnerUsername = "Dave"
                    },
                    new ArticleModel
                    {
                        Title = "Cool this is also an article!",
                        Content = "This is also some content.",
                        DateTimePosted = DateTime.UtcNow,
                        OwnerUsername = "Jimmy"
                    },
                    new ArticleModel
                    {
                        Title = "Great, another article",
                        Content = "Even more content.",
                        DateTimePosted = DateTime.UtcNow,
                        OwnerUsername = "Bob"
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
