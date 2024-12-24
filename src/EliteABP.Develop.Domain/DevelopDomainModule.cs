using Volo.Abp.Domain;

namespace EliteABP.Develop;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(DevelopDomainSharedModule)
)]
public class DevelopDomainModule : AbpModule
{

}