using System;
using System.Data.Entity;
using DAL.Contexts;
using DAL.Repositories;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository ArticleRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ITagRepository TagRepository { get; }
        void Commit();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MagazineContext context = new MagazineContext();
        private IArticleRepository articleRepository;

        public IArticleRepository ArticleRepository => articleRepository = articleRepository ?? new ArticleRepository(context);
        private ICategoryRepository categoryRepository;
        public ICategoryRepository CategoryRepository => categoryRepository = categoryRepository ?? new CategoryRepository(context);
        private ITagRepository tagRepository;

        public ITagRepository TagRepository => tagRepository = tagRepository ?? new TagRepository(context);

        public void Commit()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); //Output ekranına basar.
                Dispose();
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
