using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Degree53_BlogTechTest.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Degree53_BlogTechTest.Controllers
{
    public class ChecklistController : Controller
    {
        private readonly ILogger<ChecklistController> _logger;
        private readonly IBlogRepository _repo;

        public ChecklistController(ILogger<ChecklistController> logger, IBlogRepository repo)
        {
            this._logger = logger;
            this._repo = repo;
        }

        public ViewResult Index()
        {
            return View();
        }
    }
}
