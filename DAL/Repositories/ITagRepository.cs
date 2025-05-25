using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts;
using DAL.Entities;

namespace DAL.Repositories
{
    public interface ITagRepository : IGenericRepository<Tag>
    {

    }
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(MagazineContext context) : base(context) { }
    }
}
