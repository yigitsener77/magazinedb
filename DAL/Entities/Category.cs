using System.Collections.Generic;

namespace DAL.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
