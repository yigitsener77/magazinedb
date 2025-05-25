using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public string Content { get; set; }
        public string CoverImagePath { get; set; }

        [ForeignKey(nameof(Category))] //Bu özellik CategoryId ile Category Entity yapısındaki Id'yi kullanarak yabancı anahtar (Foreign Key) oluşturur.
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public DateTime? PublishDate { get; set; }
        public bool Draft { get; set; } = true;
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
