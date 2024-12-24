using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace EliteABP.Develop.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DevelopDomainModule),
    typeof(DevelopEntityFrameworkModule)
)]
public class DevelopDbMigratorModule : AbpModule
{

}