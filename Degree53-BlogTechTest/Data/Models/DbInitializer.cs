using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Degree53_BlogTechTest.Data.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            // AppDbContext context = builder.ApplicationServices.GetRequiredService<AppDbContext>();

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
