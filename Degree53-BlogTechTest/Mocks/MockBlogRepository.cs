using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Degree53_BlogTechTest.Interfaces;
using Degree53_BlogTechTest.Models;

namespace Degree53_BlogTechTest.Mocks
{
    public class MockBlogRepository : IBlogRepository
    {
        public IEnumerable<ArticleModel> Articles
        {
            get
            {
                return new List<ArticleModel>
                {
                    new ArticleModel
                    {
                        Id = 1,
                        Title = "Wow this is an article!"
                    },
                    new ArticleModel
                    {
                        Id = 2,
                        Title = "Cool this is also an article!"
                    }
                };
            }
        }

        public ArticleModel GetArticle(int articleId)
        {
            return this.Articles.Where(article => article.Id == articleId).FirstOrDefault();
        }
    }
}
