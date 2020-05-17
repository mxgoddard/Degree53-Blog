using System;
using System.Collections.Generic;
using System.Linq;
using Degree53_BlogTechTest.Data.Interfaces;
using Degree53_BlogTechTest.Data.Models;
using Microsoft.Extensions.Logging;

namespace Degree53_BlogTechTest.Data.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<BlogRepository> _logger;

        public BlogRepository(AppDbContext appDbContext, ILogger<BlogRepository> logger)
        {
            this._appDbContext = appDbContext;
            this._logger = logger;
        }

        public IEnumerable<ArticleModel> Articles => this._appDbContext.Articles;

        public ArticleModel GetArticle(int articleId)
        {
            return this._appDbContext.Articles.FirstOrDefault(a => a.Id == articleId);
        }

        public ArticleModel CreateArticle(ArticleModel article)
        {
            article.DateTimePosted = DateTime.UtcNow;

            try
            {
                this._appDbContext.Articles.Add(article);
                this._appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Unable to create article. Error: {ex.Message}");
            }

            return article;
        }

        public void UpdateSettings(UserModel user)
        {
            try
            {
                var entity = this._appDbContext.User.FirstOrDefault(el => el.Id == 1);

                if (entity != null)
                {
                    entity.IsAdmin = user.IsAdmin;

                    this._appDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Unable to update admin permissions to ${user.IsAdmin}. UserId should be 1 (is '${user.Id}'). Error: {ex.Message}", ex);
            }
        }

        public UserModel GetUser()
        {
            try
            {
                return this._appDbContext.User.First(el => el.Id == 1);
            } 
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Unable to determine whether user is an admin. This could be because the database hasn't seeded correctly. Error: {ex.Message}");
                return new UserModel { IsAdmin = false };
            }
        }
    }
}
