using System.Collections.Generic;
using Degree53_BlogTechTest.Data.Models;

namespace Degree53_BlogTechTest.Data.Interfaces
{
    public interface IBlogRepository
    {
        public IEnumerable<ArticleModel> Articles { get; }

        public ArticleModel GetArticle(int articleId);

        public ArticleModel CreateArticle(ArticleModel article);

        public void UpdateSettings(UserModel user);

        public UserModel GetUser();

        public void DeleteArticle(int articleId);
    }
}
