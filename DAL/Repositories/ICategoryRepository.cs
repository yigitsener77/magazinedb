using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contexts;
using DAL.Entities;

namespace DAL.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MagazineContext context) : base(context)
        {

        }
    }
}
