using EliteABP.Develop.TestBase;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace EliteABP.Develop.EntityFramework.Tests;

[DependsOn(
    typeof(AbpEntityFrameworkCoreSqliteModule),
    typeof(DevelopTestBaseModule),
    typeof(DevelopEntityFrameworkModule))]
public class DevelopEntityFrameworkTestModule : AbpModule
{
    SqliteConnection _sqliteConnection = null!;
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        _sqliteConnection = CreateDatabaseAndGetConnection();

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(config =>
            {
                config.DbContextOptions.UseSqlite(_sqliteConnection);
            });
        });
    }
    static SqliteConnection CreateDatabaseAndGetConnection()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<DevelopDbContext>()
            .UseSqlite(connection)
            .Options;

        using var context = new DevelopDbContext(options);
        context.GetService<IRelationalDatabaseCreator>().CreateTables();

        return connection;
    }
    public override void OnApplicationShutdown(ApplicationShutdownContext context)
    {
        _sqliteConnection.Dispose();
    }
}