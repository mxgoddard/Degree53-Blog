using System;
using System.Collections.Generic;
using Degree53_BlogTechTest.Controllers;
using Degree53_BlogTechTest.Data.Interfaces;
using Degree53_BlogTechTest.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Degree53_BlogTechTest.Tests
{
    public class Tests
    {
        private Mock<IBlogRepository> _mockBlogRepo;
        private Mock<ILogger<ArticleController>> _mockArticleControllerLogger;
        private Mock<ILogger<HomeController>> _mockHomeControllerLogger;
        private Mock<ILogger<SettingsController>> _mockSettingsControllerLogger;

        private ArticleController _articleController;
        private HomeController _homeController;
        private SettingsController _settingsController;

        [SetUp]
        public void Setup()
        {
            this._mockBlogRepo = new Mock<IBlogRepository>();
            this._mockArticleControllerLogger = new Mock<ILogger<ArticleController>>();
            this._mockHomeControllerLogger = new Mock<ILogger<HomeController>>();
            this._mockSettingsControllerLogger = new Mock<ILogger<SettingsController>>();

            this._articleController = new ArticleController(this._mockBlogRepo.Object, this._mockArticleControllerLogger.Object);
            this._homeController = new HomeController(this._mockHomeControllerLogger.Object, this._mockBlogRepo.Object);
            this._settingsController = new SettingsController(this._mockSettingsControllerLogger.Object, this._mockBlogRepo.Object);
        }

        [Test]
        public void ArticleController_Article_GreenPath()
        {
            // Arrange
            int id = 1;

            ArticleModel article = new ArticleModel() { Id = 1 };

            this._mockBlogRepo.Setup(x => x.GetArticle(It.IsAny<int>())).Returns(article);

            // Assert
            Assert.DoesNotThrow(() => this._articleController.Article(id));
        }

        [Test]
        public void ArticleController_Article_RedPath()
        {
            // Arrange
            int id = 1;

            ArticleModel article = new ArticleModel() { Id = 1 };

            this._mockBlogRepo.Setup(x => x.GetArticle(It.IsAny<int>())).Throws<Exception>();

            // Act
            var result = this._articleController.Article(id);

            // Assert
            Assert.DoesNotThrow(() => this._articleController.Article(id));
        }

        [Test]
        public void ArticleController_Add_GreenPath()
        {
            // Arrange
            ArticleModel article = new ArticleModel() 
            { 
                Id = 1,
                Title = "Title",
                Content = "Content",
                DateTimePosted = DateTime.Now,
                OwnerUsername = "User"
            };

            // Assert
            Assert.DoesNotThrow(() => this._articleController.Add(article));
        }

        [Test]
        public void ArticleController_Add_RedPath()
        {
            // Assert
            Assert.DoesNotThrow(() => this._articleController.Add(new ArticleModel()));
        }

        [Test]
        public void ArticleController_Delete_GreenPath()
        {
            // Assert
            Assert.DoesNotThrow(() => this._articleController.DeleteArticle(new ArticleModel() { Id = 1 }));
        }

        [Test]
        public void ArticleController_Delete_RedPath()
        {
            // Assert
            Assert.DoesNotThrow(() => this._articleController.DeleteArticle(new ArticleModel()));
        }

        [Test]
        public void HomeController_Index_GreenPath()
        {
            // Arrange
            List<ArticleModel> articles = new List<ArticleModel>()
            {
                new ArticleModel()
                {
                    Id = 1,
                    Title = "Title",
                    Content = "Content",
                }
            };

            this._mockBlogRepo.Setup(x => x.Articles).Returns(articles);

            // Assert
            Assert.DoesNotThrow(() => this._homeController.Index());
        }

        [Test]
        public void HomeController_Index_RedPath()
        {
            // Assert
            Assert.DoesNotThrow(() => this._homeController.Index());
        }

        [Test]
        public void SettingsController_Settings()
        {
            // Arrange
            UserModel user = new UserModel()
            {
                Id = 1,
                IsAdmin = false
            };

            this._mockBlogRepo.Setup(x => x.GetUser()).Returns(user);

            // Assert
            Assert.DoesNotThrow(() => this._settingsController.Settings());
        }

        [Test]
        public void SettingsController_Settings_Overloaded()
        {
            // Arrange
            UserModel user = new UserModel()
            {
                Id = 1,
                IsAdmin = false
            };

            // Assert
            Assert.DoesNotThrow(() => this._settingsController.Settings(user));
        }
    }
}