using Degree53_BlogTechTest.Data.Interfaces;
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

        public ViewResult Index()
        {
            ArticleListViewModel vm = new ArticleListViewModel();
            vm.Articles = _blogRepo.Articles;
            vm.word = "Hello, World!";

            return View(vm);
        }

        public ViewResult ListArticles()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}