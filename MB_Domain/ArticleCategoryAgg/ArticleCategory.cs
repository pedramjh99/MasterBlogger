using System;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public int Id { get; private set; }
        public string Title { get;private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get;private set; }
        public ArticleCategory(string title, IArticleCategoryValidatorService validate)
        {
            Validation(title);
            validate.CheckrecordExist(title);
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }

        public void Rename(string title, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            Validation(title);
            Title = title; 
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
        //valditaion haye samte serveram dar in laye domain minevisim

        public void Validation(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }
        
    }
}
