using EliteABP.Develop.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace EliteABP.Develop;

[DependsOn(
    typeof(DevelopDomainModule),
    typeof(AbpAutoMapperModule))]
public class DevelopApplicationContractModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<DevelopApplicationContractModule>();
            //options.AddProfile<AuthorProfile>(true);
        });
    }
}