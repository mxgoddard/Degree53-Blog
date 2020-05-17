using System;
using Degree53_BlogTechTest.Data.Interfaces;
using Degree53_BlogTechTest.Data.Models;
using Degree53_BlogTechTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Degree53_BlogTechTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogRepository _blogRepo;

        public HomeController(ILogger<HomeController> logger, IBlogRepository blogRepo)
        {
            _logger = logger;
            _blogRepo = blogRepo;
        }

        // Display all articles on the homepage
        public ViewResult Index()
        {
            ArticleListViewModel vm = new ArticleListViewModel()
            {
                Articles = _blogRepo.Articles,
                IsAdmin = _blogRepo.GetUser().IsAdmin
            };

            return View(vm);
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

        public ViewResult Settings()
        {
            UserModel user = _blogRepo.GetUser();
            _logger.LogInformation($"{user.Id}, {user.IsAdmin}.");
            return View(user);
        }

        [HttpPost]
        public IActionResult Settings(UserModel user)
        {
            _logger.LogInformation($"Attempting to update settings for UserId: {user.Id} to an AdminRole: {user.IsAdmin}.");

            this._blogRepo.UpdateSettings(user);

            return Redirect($"/Home/Settings");
        }

        [HttpDelete]
        public IActionResult DeleteArticle()
        {
            return Redirect($"");
        }
    }
}