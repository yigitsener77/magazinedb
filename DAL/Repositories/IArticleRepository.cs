using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts;
using DAL.Entities;

namespace DAL.Repositories
{
    public interface IArticleRepository : IGenericRepository<Article>
    {
        void MakeDeleted(int articleId);
        void Recycle(int articleId);
    }
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository 
    {
        public ArticleRepository(MagazineContext context) : base(context) 
        {

        }

        public void MakeDeleted(int articleId)
        {
            var article = ReadOne(articleId);
            article.Deleted = true;
            article.Active = false;
            article.Draft = true;
            article.PublishDate = null;
            Update(article);
        }

        public void Recycle(int articleId)
        {
            throw new NotImplementedException();
        }
    }
}
