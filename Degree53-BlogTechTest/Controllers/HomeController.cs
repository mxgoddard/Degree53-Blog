using System;
using System.Collections.Generic;
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
            ArticleListViewModel vm = new ArticleListViewModel();

            try
            {
                vm.Articles = _blogRepo.Articles;
                // vm.IsAdmin = _blogRepo.GetUser().IsAdmin;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now}: Unable to retrieve articles from database. Consider checking your db connection string. Error: {ex.Message}");
                vm.Articles = new List<ArticleModel>();
            }

            return View(vm);
        }
    }
}