using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Degree53_BlogTechTest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Degree53_BlogTechTest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {       
        }

        public DbSet<ArticleModel> Articles { get; set; }

        public DbSet<UserModel> User { get; set; }
    }
}
