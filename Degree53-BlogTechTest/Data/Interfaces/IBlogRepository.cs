using System.Collections.Generic;
using Degree53_BlogTechTest.Data.Models;

namespace Degree53_BlogTechTest.Data.Interfaces
{
    public interface IBlogRepository
    {
        public IEnumerable<ArticleModel> Articles { get; }

        public ArticleModel GetArticle(int articleId);
    }
}
