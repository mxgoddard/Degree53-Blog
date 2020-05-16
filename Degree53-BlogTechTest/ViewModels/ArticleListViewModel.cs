using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Degree53_BlogTechTest.Models;

namespace Degree53_BlogTechTest.ViewModels
{
    public class ArticleListViewModel
    {
        public string word { get; set; }
        public IEnumerable<ArticleModel> Articles { get; set; }
    }
}
