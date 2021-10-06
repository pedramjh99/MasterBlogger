using System;
using MB.Domain.ArticleCategoryAgg.Exeption;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckrecordExist(string title)
        {
            if (_articleCategoryRepository.Exist(title))
            {
                throw new DuplicatedExeption("This Record is Exist");
            }
        }
    }
}