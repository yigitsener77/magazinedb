using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Panel
{
    public class ArticleEditDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public DateTime PublishDate { get; set; }
        public bool Draft { get; set; }
        public string ShortContent { get; set; }
        public string Content { get; set; }
        public string CoverImagePath { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
