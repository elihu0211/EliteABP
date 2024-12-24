using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace EliteABP.Develop.HttpApi;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(DevelopApplicationModule),
    typeof(DevelopEntityFrameworkModule)
)]
public class DevelopHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddControllers();
        context.Services.AddAbpSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Your API Title",
                Version = "v1"
            });
            options.DocInclusionPredicate((docName, description) => true);
            options.CustomSchemaIds(type => type.FullName);
            options.HideAbpEndpoints();
        });

        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(DevelopApplicationModule).Assembly, opts =>
            {
                opts.RootPath = "develop";
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

        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.RoutePrefix = string.Empty;
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Title v1");
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}