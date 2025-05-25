using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Utilities.Helpers;
using DAL.Entities;

namespace BLL.DTOs
{
    public class ArticleListItemDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public string CoverImagePath { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<string> Tags { get; set; } = new HashSet<string>();
        public int LikeCount { get; set; } = 0;
        public int DislikeCount { get; set; } = 0;
        public int CommentCount { get; set; } = 0;
        public DateTime PublishDate { get; set; }

        public ArticleListItemDTO()
        {

        }

        public ArticleListItemDTO(Article a)
        {
            Id = a.Id;
            Title = a.Title;
            ShortContent = a.ShortContent;
            CoverImagePath = a.CoverImagePath;
            PublishDate = (DateTime)a.PublishDate;
            Url = a.Title.ToUrl();
            Tags = a.Tags.Select(x => x.Name);
            CategoryName = a.Category.Name;
            CommentCount = a.Comments.Count;
            LikeCount = a.Comments.Count(x => x.Reaction == true);
            DislikeCount = a.Comments.Count(x => x.Reaction == false);
        }
    }

    public class ArticleDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public string Content { get; set; }
        public string CoverImagePath { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<string> Tags { get; set; } = new HashSet<string>();
        public int LikeCount { get; set; } = 0;
        public int DislikeCount { get; set; } = 0;
        public int CommentCount { get; set; } = 0;
        public DateTime PublishDate { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; }
    }

    public class CommentDTO
    {
        public string Content { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public bool? Reaction { get; set; }
    }
}
