using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Contexts
{
    public class MagazineContext : DbContext
    {
        public MagazineContext(): base("server=localhost; database=magazine_db_ders; trusted_connection=true; trustservercertificate=true;") { }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}
