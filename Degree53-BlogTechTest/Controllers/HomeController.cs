using System;
using System.Threading.Tasks;
using Degree53_BlogTechTest.Data.Interfaces;
using Degree53_BlogTechTest.Data.Models;
using Degree53_BlogTechTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            ArticleListViewModel vm = new ArticleListViewModel();
            vm.Articles = _blogRepo.Articles;

            return View(vm);
        }

        public ViewResult Article()
        {
            // Create ViewModel for individual article
            return View();
        }

        public ViewResult ListArticles()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ArticleModel article)
        {
            _logger.LogInformation($"{article.Title}, {article.Content}.");
            this._blogRepo.CreateArticle(article);

            // await this._blogRepo.CreateArticle(article);

            // if (!ModelState.IsValid) return View(article);

            return View(article);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}