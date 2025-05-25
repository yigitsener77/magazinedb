using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DTOs;

namespace Site.Models
{
    public class ArticlesViewModel
    {
        public IEnumerable<ArticleListItemDTO> Articles { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public int? SelectedCategoryId { get; set; }
        public string SelectedTagName { get; set; }
    }
}