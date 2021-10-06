using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        void Add(ArticleCategory entity);
        List<ArticleCategory> GetAll();
        ArticleCategory Get(int id);
        void Save();
        bool Exist(string title);

    }
}
