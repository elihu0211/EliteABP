using EliteABP.Develop.EntityFramework.Tests;
using Volo.Abp.Modularity;

namespace EliteABP.Develop.Application.Tests;

[DependsOn(
    typeof(DevelopApplicationModule),
    typeof(DevelopEntityFrameworkTestModule))]
public class DevelopApplicationTestModule : AbpModule
{

}