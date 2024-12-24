using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Data;

namespace EliteABP.Develop.Authors.Data;

[Dependency(ServiceLifetime.Transient)]
public class AuthorDbMigretionService(IDataSeeder dataSeeder, IEnumerable<IAuthorDbSchemaMigrator> dbSchemaMigrators)
{
    public async Task MigrateAsync()
    {
        foreach (var dbSchemaMigrator in dbSchemaMigrators)
        {
            await dbSchemaMigrator.MigrateAsync().ConfigureAwait(false);
        }

        await dataSeeder.SeedAsync().ConfigureAwait(false);
    }
}