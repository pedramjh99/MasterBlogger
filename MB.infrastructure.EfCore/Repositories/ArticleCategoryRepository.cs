using MB.Domain.ArticleCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace MB.infrastructure.EfCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _db;

        public ArticleCategoryRepository(MasterBloggerContext db)
        {
            _db = db;
        }

        public void Add(ArticleCategory entity)
        {
            _db.ArticleCategories.Add(entity);
            Save();
        }

        public bool Exist(string title)
        {
            return _db.ArticleCategories.Any(x => x.Title == title);
        }

        public ArticleCategory Get(int id)
        {
            return _db.ArticleCategories.FirstOrDefault(x => x.Id==id);
        }

        public List<ArticleCategory> GetAll()
        {
            var result = _db.ArticleCategories.ToList();
            return result;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
