using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Degree53_BlogTechTest.Data.Interfaces;
using Degree53_BlogTechTest.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Degree53_BlogTechTest.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly IBlogRepository _blogRepo;

        public SettingsController(ILogger<SettingsController> logger, IBlogRepository blogRepo)
        {
            this._logger = logger;
            this._blogRepo = blogRepo;
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

            return Redirect($"/Settings/Settings");
        }
    }
}
