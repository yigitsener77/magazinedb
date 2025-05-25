using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DAL.Repositories
{
    //Strong Type(T): Baskın tip, bu genel sınıf yapıları için kullanılan bir düzendir. T yerine hangi sınıf gelirse bu sınıf onun için çalışmaya başlar.
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        TEntity ReadOne(int entityKey);
        //IEnumerable, List yapısının temelini oluşturur. Fakat soyut bir düzende çalışır, bu sayede bellek taşmasına engel olunur.
        IEnumerable<TEntity> ReadAll(params string[] includes);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int entityKey);
    }
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> _entities;
        private readonly DbContext db;
        protected GenericRepository(DbContext context)
        {
            //Veritabanı tablolarından TEntity sınıfına karşılık gelenin atamasını yapar.
            _entities = context.Set<TEntity>();
            db = context;
        }

        public void Create(TEntity entity)
        {
            //INSERT INTO{TEntity} (...{TEntity Properties}) VALUES {entity.values}
            _entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            // DELETE FROM {TEntity} WHERE {TEntity.PrimaryKey/EntityKey} = {entity.PrimaryKey/EntityKey}
            _entities.Remove(entity);
        }

        public void Delete(int entityKey)
        {
            var entity = ReadOne(entityKey);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public IEnumerable<TEntity> ReadAll(params string[] includes)
        {
            // SELECT * FROM {TEntity} JOIN {includes}
            IQueryable<TEntity> data = _entities;
            foreach (var include in includes)
            {
                data = data.Include(include);
            }
            return data;
        }

        public TEntity ReadOne(int entityKey)
        {
            // SELECT TOP 1 * FROM {TEntity} WHERE {TEntity.PrimaryKey/EntityKey} = {entity.PrimaryKey/EntityKey}

            return _entities.Find(entityKey);
        }

        public void Update(TEntity entity)
        {
            // UPDATE {TEntity} SET ...{TEntity Properties} = {entity.newValues} WHERE {TEntity.PrimaryKey/EntityKey} = {entity.PrimaryKey/EntityKey}
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
