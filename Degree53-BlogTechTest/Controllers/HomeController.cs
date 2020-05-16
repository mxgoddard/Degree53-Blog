using Degree53_BlogTechTest.Interfaces;
using Degree53_BlogTechTest.Models;
using Degree53_BlogTechTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult ListArticles()
        {
            ArticleListViewModel vm = new ArticleListViewModel();
            vm.Articles = _blogRepo.Articles;
            vm.word = "Hello, World!";

            return View(vm);
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