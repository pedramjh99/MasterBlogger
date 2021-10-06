using MB.Application;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.Extensions.DependencyInjection;
using MB.Domain.ArticleCategoryAgg;
using MB.infrastructure.EfCore;
using MB.infrastructure.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddDbContext<MasterBloggerContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
