﻿using System;
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
    }
}