using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Degree53_BlogTechTest.Data.Models
{
    public class DbInitializer
    {
        private readonly static string loremContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris vel facilisis nisi. Cras pellentesque elit at vehicula mollis. Nulla quis massa euismod, auctor nulla non, imperdiet sem. In sit amet posuere urna. Mauris purus libero, varius vitae pulvinar at, mattis ac ex. Integer quis erat lorem. Proin velit arcu, iaculis sit amet est sed, pretium mattis ante. Nunc sed tellus non turpis imperdiet vestibulum. Nullam diam felis, varius eu dolor et, vestibulum tristique diam. Aliquam vel libero ac lectus dignissim pellentesque. Duis ac sem pellentesque, condimentum ipsum a, semper mi. Nullam vel mi eleifend risus faucibus mattis ut sed mi. Integer eu est a arcu placerat maximus eget eu libero. Nam ultricies purus sit amet ipsum vulputate facilisis. Suspendisse potenti. Mauris ut vulputate ex. Morbi quis viverra risus. Praesent id sem tempus, commodo turpis sit amet, lobortis nibh. Mauris consequat feugiat nibh. Donec nec massa egestas, porttitor diam ut, venenatis lectus. Interdum et malesuada fames ac ante ipsum primis in faucibus. Cras vestibulum lacinia quam ut tincidunt. In mollis suscipit ornare. In a molestie neque, quis efficitur neque. Suspendisse efficitur nunc nec arcu tincidunt volutpat.";

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
                        Content = loremContent,
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
                    },
                    new ArticleModel
                    {
                        Title = "CSS? Never heard of it.",
                        Content = "This content isn't the most creative.",
                        DateTimePosted = DateTime.UtcNow,
                        OwnerUsername = "Susan"
                    },
                    new ArticleModel
                    {
                        Title = "C# > C++",
                        Content = "These are my reasons to why C# is better than it's lower level counterpart, C++.",
                        DateTimePosted = DateTime.UtcNow,
                        OwnerUsername = "Jeffrey"
                    },
                    new ArticleModel
                    {
                        Title = "First post on Bloggr",
                        Content = "Hi everyone, this is my first post on Bloggr!",
                        DateTimePosted = DateTime.UtcNow,
                        OwnerUsername = "Newbie"
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
