using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg.Exeption
{
    public class DuplicatedExeption :Exception
    {
        public DuplicatedExeption()
        {
            
        }

        public DuplicatedExeption(string message) : base(message)
        {
            
        }
    }
}
