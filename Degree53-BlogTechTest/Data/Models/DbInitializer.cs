using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Degree53_BlogTechTest.Data.Models
{
    public class DbInitializer
    {
        // Seed database
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Create the admin user with an id of 1 if it doesn't already exist
            if (!context.User.Where(user => user.Id == 1).Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[User] ON");

                    context.Add(new UserModel() { Id = 1, IsAdmin = false });
                    context.SaveChanges();

                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[User] OFF");

                    transaction.Commit();
                }
            }

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
