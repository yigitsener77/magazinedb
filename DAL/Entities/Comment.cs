using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Comment : BaseEntity
    {
        [ForeignKey(nameof(Article))]

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        //True = LIKE, False = DISLIKE, Property is Nullable 
        
        public bool? Reaction { get; set; }
        
        [Required] //Veritabanına bu sütun zorunludur (Not Null) bilgisi gönderir.
        public string Content { get; set; }

        public string Email { get; set; }
        
        [Required]
        public string Fullname { get; set; }
    }
}
