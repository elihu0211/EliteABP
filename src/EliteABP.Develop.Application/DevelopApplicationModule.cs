using Volo.Abp.Modularity;

namespace EliteABP.Develop;

[DependsOn(typeof(DevelopApplicationContractModule))]
public class DevelopApplicationModule : AbpModule
{

}