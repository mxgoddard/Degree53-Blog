using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Degree53_BlogTechTest.Models;

namespace Degree53_BlogTechTest.Interfaces
{
    public interface IBlogRepository
    {
        public IEnumerable<ArticleModel> Articles { get; }

        public ArticleModel GetArticle(int articleId);
    }
}
