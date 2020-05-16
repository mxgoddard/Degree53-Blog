using System;
using System.Collections.Generic;
using System.Linq;
using Degree53_BlogTechTest.Data.Interfaces;
using Degree53_BlogTechTest.Data.Models;

namespace Degree53_BlogTechTest.Data.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private string content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eu eleifend ipsum. Nam tempus metus sed metus auctor commodo. Integer sagittis imperdiet turpis. Nulla dignissim, augue vitae pharetra convallis, nisl tortor ultricies nisl, ultricies fermentum justo augue ac tellus. Curabitur egestas tortor sit amet ornare volutpat. Praesent finibus semper urna sed fringilla. Donec scelerisque purus eget magna imperdiet, at placerat dolor rutrum. Phasellus scelerisque varius ullamcorper. Sed eu ante mauris. Duis euismod, libero a efficitur viverra, mauris metus posuere erat, sed porta elit eros non elit. Pellentesque tincidunt, massa a tempus vestibulum, diam eros porta mi, nec viverra nulla libero id nisi. Donec fermentum, est et lobortis gravida, augue quam tristique nunc, non luctus velit ipsum eu nulla. Proin at orci at dolor semper dapibus. Nullam vitae enim at purus pretium finibus. Pellentesque mauris ex, accumsan ut enim id, tempor faucibus nunc. Duis vulputate eleifend tortor non imperdiet.";
        private readonly AppDbContext _appDbContext;

        public BlogRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public IEnumerable<ArticleModel> Articles => this._appDbContext.Articles;

        public ArticleModel GetArticle(int articleId) => this._appDbContext.Articles.FirstOrDefault(a => a.Id == articleId);
    }
}
