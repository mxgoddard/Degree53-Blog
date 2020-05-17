using Degree53_BlogTechTest.Data.Interfaces;
using Degree53_BlogTechTest.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Degree53_BlogTechTest.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IBlogRepository _blogRepo;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(IBlogRepository blogRepo, ILogger<ArticleController> logger)
        {
            this._blogRepo = blogRepo;
            this._logger = logger;
        }

        // Show a specific article referenced by the article id
        public ViewResult Article(int id)
        {
            // Validation needed here that id is valid
            ArticleModel article = _blogRepo.GetArticle(id);

            return View(article);
        }
    }
}
