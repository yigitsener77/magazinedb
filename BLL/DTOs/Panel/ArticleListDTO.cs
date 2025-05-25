using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Panel
{
    public class ArticleListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Draft { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }
}
