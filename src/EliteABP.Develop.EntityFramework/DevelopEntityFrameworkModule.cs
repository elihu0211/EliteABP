using EliteABP.Develop.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Modularity;

namespace EliteABP.Develop;

[DependsOn(typeof(AbpEntityFrameworkCorePostgreSqlModule))]
public class DevelopEntityFrameworkModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<DevelopDbContext>(options =>
        {
            // 添加聚合根倉儲的實體
            options.AddDefaultRepositories();
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseNpgsql();
        });

        // 手動添加導航屬性實體
        Configure<AbpEntityOptions>(options =>
        {
            options.Entity<Book>(entityOptions =>
            {
                entityOptions.DefaultWithDetailsFunc = query =>
                query.Include(book => book.Volumes).ThenInclude(volume => volume.Chapters);
            });
        });
    }
}