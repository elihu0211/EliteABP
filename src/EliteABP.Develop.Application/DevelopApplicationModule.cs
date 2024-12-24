using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace EliteABP.Develop;

[DependsOn(
    typeof(AbpAutoMapperModule),
    typeof(AbpDddApplicationModule),
    typeof(DevelopDomainModule),
    typeof(DevelopApplicationContractModule)
)]
public class DevelopApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<DevelopApplicationModule>();
        });
    }
}