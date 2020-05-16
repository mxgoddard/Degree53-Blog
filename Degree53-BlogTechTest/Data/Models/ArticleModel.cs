using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degree53_BlogTechTest.Data.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateTimePosted { get; set; }

        public string OwnerUsername { get; set; }
    }
}
