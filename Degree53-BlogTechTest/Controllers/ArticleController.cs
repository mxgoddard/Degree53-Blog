using System;
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
        public IActionResult Article(int id)
        {
            // Validation needed here that id is valid
            try
            {
                ArticleModel article = _blogRepo.GetArticle(id);
                return View(article);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Unable to retrieve data for article with an id of {id}. Error: {ex.Message}");
                return Redirect($"/Home");
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ArticleModel article)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrWhiteSpace(article.OwnerUsername))
                {
                    article.OwnerUsername = "Anonymous";
                }

                this._blogRepo.CreateArticle(article);

                return Redirect($"/Article/Article/{article.Id}");
            }

            return View(article);
        }

        // Can't get HttpDelete to work for some reason
        [HttpPost]
        public IActionResult DeleteArticle(ArticleModel article)
        {
            this._blogRepo.DeleteArticle(article.Id);
            return Redirect($"/Home");
        }
    }
}
