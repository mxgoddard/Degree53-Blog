using System.Collections.Generic;
using Degree53_BlogTechTest.Data.Models;

namespace Degree53_BlogTechTest.ViewModels
{
    public class ArticleListViewModel
    {
        public IEnumerable<ArticleModel> Articles { get; set; }
        public bool IsAdmin { get; set; }
    }
}
