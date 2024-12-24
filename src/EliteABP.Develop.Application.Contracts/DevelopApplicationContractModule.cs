using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace EliteABP.Develop;

[DependsOn(
    typeof(DevelopDomainSharedModule),
    typeof(AbpDddApplicationContractsModule)
)]
public class DevelopApplicationContractModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}