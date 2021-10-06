using MB.Application.Contracts;
using MB.Domain.ArticleCategoryAgg;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title);
            _articleCategoryRepository.Add(articleCategory);
        }

       

        public List<ArticleCategoryViewModel> List()
        {
            //Get All Category
            var articleCategories = _articleCategoryRepository.GetAll();
            var result = new List<ArticleCategoryViewModel>();
            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    Title = articleCategory.Title,
                    IsDeleted = articleCategory.IsDeleted,
                    CreationDate = articleCategory.CreationDate.ToString(CultureInfo.InvariantCulture)
                });
            }

            return result;
        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title,_articleCategoryValidatorService);
            _articleCategoryRepository.Save();
        }
        public RenameArticleCategory Get(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategory
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title
            };
        }

        public void Remove(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();
            _articleCategoryRepository.Save();
        }

        public void Activate(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
            _articleCategoryRepository.Save();
        }
    }
}
