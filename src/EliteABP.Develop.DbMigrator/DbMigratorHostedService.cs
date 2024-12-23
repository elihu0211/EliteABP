using EliteABP.Develop.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace EliteABP.Develop.DbMigrator;
public class DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var application = await AbpApplicationFactory.CreateAsync<DevelopDbMigratorModule>(options =>
        {
            options.UseAutofac();
        });

        await application.InitializeAsync();

        // 執行遷移
        await application.ServiceProvider.GetRequiredService<NovelDbMigretionService>().MigrateAsync();

        await application.ShutdownAsync();

        hostApplicationLifetime.StopApplication();
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}