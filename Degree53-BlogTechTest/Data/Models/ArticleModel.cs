using System;
using System.ComponentModel.DataAnnotations;
using Degree53_BlogTechTest.ViewModels;

namespace Degree53_BlogTechTest.Data.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateTimePosted { get; set; }

        public string OwnerUsername { get; set; }
    }
}
