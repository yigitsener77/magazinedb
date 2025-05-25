using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Utilities.Helpers;
using BLL.Utilities.Maps;
using DAL;
using DAL.Entities;

namespace BLL.Services
{
    public interface IMagazineService
    {
        IEnumerable<ArticleListItemDTO> GetArticles();
        IEnumerable<ArticleListItemDTO> GetArticlesByCategory(string categoryName);
        IEnumerable<ArticleListItemDTO> GetArticlesByTag(string tagName);
        IEnumerable<CategoryDTO> GetCategories();
        ArticleDetailDTO GetArticleDetail(int id);
    }

    public class MagazineService : IMagazineService
    {
        private readonly IUnitOfWork uow = new UnitOfWork();

        public ArticleDetailDTO GetArticleDetail(int id)
        {
            Article a = uow.ArticleRepository.ReadOne(id);
            IEnumerable<CommentDTO> comments = from c in a.Comments
                                               where c.Active && !c.Deleted
                                               select new CommentDTO
                                               {
                                                   Content = c.Content,
                                                   Email = c.Email,
                                                   Fullname = c.Fullname,
                                                   Reaction = c.Reaction
                                               };
            return new ArticleDetailDTO
            {
                Id = a.Id,
                Title = a.Title,
                ShortContent = a.ShortContent,
                Content = a.Content,
                CoverImagePath = a.CoverImagePath,
                PublishDate = (DateTime)a.PublishDate,
                Tags = a.Tags.Select(x => x.Name),
                CategoryName = a.Category.Name,
                CommentCount = a.Comments.Count,
                LikeCount = a.Comments.Count(x => x.Reaction == true),
                DislikeCount = a.Comments.Count(x => x.Reaction == false),
                Comments = comments
            };
        }

        public IEnumerable<ArticleListItemDTO> GetArticles()
        {/*
            IEnumerable<Article> articles = uow.ArticleRepository.ReadAll();
            IEnumerable<Article> publishedArticles = articles.Where(x => x.Active && !x.Deleted && !x.Draft && x.PublishDate != null);

            List<ArticleListItemDTO> result = new List<ArticleListItemDTO>();
            foreach (var a in publishedArticles)
            {
                var item = new ArticleListItemDTO
                {
                    Id = a.Id,
                    Title = a.Title,
                    ShortContent = a.ShortContent,
                    CoverImagePath = a.CoverImagePath,
                    PublishDate = (DateTime)a.PublishDate
                };
                result.Add(item);
            }
            return result;
            */
            // LINQ (Language-Integrated Query): SQL sorgularının C# diline uyarlanmış halidir.
            return from a in uow.ArticleRepository.ReadAll("Tags", "Category", "Comments")
                   where a.Active && !a.Deleted && !a.Draft && a.PublishDate != null
                   select new ArticleListItemDTO(a);
        }

        public IEnumerable<ArticleListItemDTO> GetArticlesByCategory(string categoryName)
        {
            return from a in uow.ArticleRepository.ReadAll("Tags", "Category", "Comments")
                   where a.Active && !a.Deleted && !a.Draft && a.PublishDate != null && a.Category.Name.Equals(categoryName)
                   select ArticleMap.DTOMapArticle(a);
        }

        public IEnumerable<ArticleListItemDTO> GetArticlesByTag(string tagName)
        {
            return from a in uow.ArticleRepository.ReadAll("Tags", "Category", "Comments")
                   where a.Active && !a.Deleted && !a.Draft && a.PublishDate != null && a.Tags.Any(x => x.Name.Equals(tagName))
                   select new ArticleListItemDTO
                   {
                       Id = a.Id,
                       Title = a.Title,
                       ShortContent = a.ShortContent,
                       CoverImagePath = a.CoverImagePath,
                       PublishDate = (DateTime)a.PublishDate,
                       Url = a.Title.ToUrl(),
                       Tags = a.Tags.Select(x => x.Name),
                       CategoryName = a.Category.Name,
                       CommentCount = a.Comments.Count,
                       LikeCount = a.Comments.Count(x => x.Reaction == true),
                       DislikeCount = a.Comments.Count(x => x.Reaction == false)
                   };
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            return from c in uow.CategoryRepository.ReadAll()
                   where c.Active && !c.Deleted
                   select new CategoryDTO { Id = c.Id, Name = c.Name, Url = c.Name.ToUrl() };
        }
    }
}

