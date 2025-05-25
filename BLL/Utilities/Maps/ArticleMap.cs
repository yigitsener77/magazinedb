using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Utilities.Helpers;
using DAL.Entities;

namespace BLL.Utilities.Maps
{
    public static class ArticleMap
    {
        public static ArticleListItemDTO DTOMapArticle(Article a)
        {
            return new ArticleListItemDTO
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
    }
}