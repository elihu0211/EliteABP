using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace EliteABP.Develop.HttpApi;

[DependsOn(
    typeof(DevelopApplicationModule),
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAspNetCoreSerilogModule))]
public class DevelopHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddOpenApi();
        context.Services.AddControllers();

        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            // 應用服務自動映射成控制器裡的方法。(AuthorAppService)
            options.ConventionalControllers.Create(typeof(DevelopApplicationModule).Assembly, opts =>
            {
                opts.RootPath = "novel";
            });
        });
    }
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseRouting();

        // ABP 端點
        app.UseConfiguredEndpoints();

        app.UseEndpoints(endpoints =>
        {
            if (env.IsDevelopment())
            {
                endpoints.MapOpenApi();
            }
            endpoints.MapControllers();
        });
    }
}