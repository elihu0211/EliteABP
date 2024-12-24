using EliteABP.Develop.Authors.Data;
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
        {
            await application.ServiceProvider.GetRequiredService<AuthorDbMigretionService>().MigrateAsync();
        }
        await application.ShutdownAsync();

        hostApplicationLifetime.StopApplication();
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}