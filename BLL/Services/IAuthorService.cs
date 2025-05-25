using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.DTOs.Panel;
using DAL;
using DAL.Entities;

namespace BLL.Services
{
    public interface IAuthorService
    {
        #region Articles:
        IEnumerable<ArticleListDTO> GetArticles();
        ArticleEditDTO GetArticleForEdit(int id);
        void CreateArticle(ArticleCreateDTO article);
        void UpdateArticle(ArticleEditDTO article);
        #endregion


        #region Categories:
        IEnumerable<CategoryListDTO> GetCategories();
        void CreateCategory(string name);
        void UpdateCategory(int id, string name);
        #endregion

        #region Publishing:
        // Publishing:
        /*
        DateTime? PublishArticle(int id);
        void UnpublishArticle(int id);
        */
        DateTime? TogglePublishingArticle(int id);
        #endregion

        #region Activating:
        // Activating:
        /*
        void ActivateArticle(int id);
        void DeactivateArticle(int id);
        */
        bool ToggleActivationArticle(int id);
        bool ToggleActivationCategory(int id);
        #endregion

        #region Recycling & Deleting:
        //Recycling & Deleting:
        /*
        void RecycleArticle(int id);
        void DeleteArticle(int id);
        */      
        bool ToggleRecyclingArticle(int id);
        bool ToggleRecyclingCategory(int id);
        #endregion

        #region Commenting:
        //Commenting:
        void ApproveComment(int articleId, int commentId);
        void DeleteComment(int articleId, int commentId, bool permanent = false);
        #endregion
    }

    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork uow = new UnitOfWork();
        /*
        public void ActivateArticle(int id)
        {
            var article = uow.ArticleRepository.ReadOne(id);
            article.Active = true;
            article.Deleted = false;
            uow.ArticleRepository.Update(article);
            uow.Commit();
        }
        */

        /*
        public void DeactivateArticle(int id)
        {
            var article = uow.ArticleRepository.ReadOne(id);
            article.Active = false;
            uow.ArticleRepository.Update(article);
            uow.Commit();
        }
        */

        public void ApproveComment(int articleId, int commentId)
        {
            throw new NotImplementedException();
        }

        public void CreateArticle(ArticleCreateDTO article)
        {
            throw new NotImplementedException();
        }

        public bool ToggleActivationArticle(int id)
        {
            var article = uow.ArticleRepository.ReadOne(id);
            if (article.Active)
            {
                article.Active = false;
            }
            else
            {
                article.Active = true;
                article.Deleted = false;
            }
            uow.ArticleRepository.Update(article);
            uow.Commit();
            return article.Active;
        }

        /*
        public void DeleteArticle(int id)
        {
            var article = uow.ArticleRepository.ReadOne(id);
            article.Active = false;
            article.Deleted = true;
            article.PublishDate = null;
            article.Draft = true;
            uow.ArticleRepository.Update(article);
            uow.Commit();

        }
        */

        /*
        public void RecycleArticle(int id)
        {
            var article = uow.ArticleRepository.ReadOne(id);
            article.Deleted = false;
            uow.ArticleRepository.Update(article);
             uow.Commit();
        }
        */

        /*
        public DateTime? PublishArticle(int id)
        {
            var article = uow.ArticleRepository.ReadOne(id);
            if (article.Active && !article.Deleted)
        {
            article.PublishDate = DateTime.Now;
            article.Draft = false;
            uow.ArticleRepository.Update(article);
            uow.Commit();
        }
        return article.PublishDate;
        }

        public void UnpublishArticle(int id)
        {
            var article = uow.ArticleRepository.ReadOne(id);
            article.PublishDate = null;
            article.Draft = true;
            uow.ArticleRepository.Update(article);
            uow.Commit();
        }
        */
        public DateTime? TogglePublishingArticle(int id)
        {
            var article = uow.ArticleRepository.ReadOne(id);
            if (article.Draft && article.PublishDate == null && article.Active && !article.Deleted)
            {
                article.PublishDate = DateTime.Now;
                article.Draft = false;
            }
            else
            {
                article.PublishDate = null;
                article.Draft = true;
            }
            uow.ArticleRepository.Update(article) ;
            uow.Commit();
            return article.PublishDate;
        }

        public bool ToggleRecyclingArticle(int id)
        {
            var article = uow.ArticleRepository.ReadOne(id);
            if (article.Deleted)
            {
                article.Deleted = false;
            }
            else
            {
                article.Active = false;
                article.Deleted = true;
                article.PublishDate = null;
                article.Draft = true;
            }
            uow.ArticleRepository.Update(article);
            uow.Commit();
            return article.Deleted;
        }

        public void DeleteComment(int articleId, int commentId, bool permanent = false)
        {
            throw new NotImplementedException();
        }

        public ArticleEditDTO GetArticleForEdit(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleListDTO> GetArticles()
        {
            return from a in uow.ArticleRepository.ReadAll("Category")
                   select new ArticleListDTO
                   {
                       Id = a.Id,
                       Title = a.Title,
                       Active = a.Active,
                       Deleted = a.Deleted,
                       CategoryId = a.CategoryId,
                       CategoryName = a.Category.Name,
                       CreateDate = a.CreateDate,
                       Draft = a.Draft,
                       PublishDate = a.PublishDate


                   };
        }


        public void UpdateArticle(ArticleEditDTO article)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryListDTO> GetCategories()
        {
            var data = uow.CategoryRepository.ReadAll("Articles");
            return from c in data
                   select new CategoryListDTO
                   {
                       Id = c.Id,
                       Name = c.Name,
                       Active = c.Active,
                       Deleted = c.Deleted,
                       CreateDate = c.CreateDate,
                       ArticleCount = c.Articles.Count
                   };
        }

        public bool ToggleActivationCategory(int id)
        {
            var category = uow.CategoryRepository.ReadOne(id);
            if(category.Active)
            {
                category.Active = false;
            }
            else
            {
                category.Active = true;
                category.Deleted = false;
            }
            uow.CategoryRepository.Update(category);
            uow.Commit();
            return category.Active;
        }

        public bool ToggleRecyclingCategory(int id)
        {
            var category = uow.CategoryRepository.ReadOne(id);
            if (category.Deleted)
            {
                category.Deleted = false;
            }
            else
            {
                category.Active = false;
                category.Deleted = true;
            }
            uow.CategoryRepository.Update(category);
            uow.Commit();
            return category.Deleted;
        }

        public void CreateCategory(string name)
        {
            uow.CategoryRepository.Create(new Category { Name = name });
            uow.Commit();
        }

        public void UpdateCategory(int id, string name)
        {
            var category = uow.CategoryRepository.ReadOne(id);
            if(category != null)
            {
                category.Name = name;
                uow.CategoryRepository.Update(category);
                uow.Commit();
            }
        }
    }
}
