using System;
using System.Collections.Generic;
using System.Linq;
using Degree53_BlogTechTest.Data.Interfaces;
using Degree53_BlogTechTest.Data.Models;

namespace Degree53_BlogTechTest.Data.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _appDbContext;

        public BlogRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public IEnumerable<ArticleModel> Articles => this._appDbContext.Articles;

        public ArticleModel GetArticle(int articleId) => this._appDbContext.Articles.FirstOrDefault(a => a.Id == articleId);
    }
}
