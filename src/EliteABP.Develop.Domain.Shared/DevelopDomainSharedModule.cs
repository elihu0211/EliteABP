using EliteABP.Develop.Localization;
using System.Reflection;
using Volo.Abp.Domain;
using Volo.Abp.FluentValidation;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace EliteABP.Develop;

[DependsOn(
    typeof(AbpLocalizationModule),
    typeof(AbpDddDomainSharedModule),
    typeof(AbpFluentValidationModule)
)]
public class DevelopDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            // "YourRootNameSpace" is the root namespace of your project. It can be empty if your root namespace is empty.
            options.FileSets.AddEmbedded<DevelopDomainSharedModule>("YourRootNameSpace");
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<DevelopResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/Develop");

            options.DefaultResourceType = typeof(DevelopResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Develop", typeof(DevelopResource));
        });
    }
}