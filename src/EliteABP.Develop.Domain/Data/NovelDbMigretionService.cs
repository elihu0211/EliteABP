using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Data;

namespace EliteABP.Develop.Data;

[Dependency(ServiceLifetime.Transient)]
public class NovelDbMigretionService(IDataSeeder dataSeeder, IEnumerable<INovelDbSchemaMigrator> dbSchemaMigrators)
{
    public async Task MigrateAsync()
    {
        foreach (var dbSchemaMigrator in dbSchemaMigrators)
        {
            // 資料遷移
            await dbSchemaMigrator.MigrateAsync().ConfigureAwait(false);
        }

        // 資料播種
        //await dataSeeder.SeedAsync().ConfigureAwait(false);
    }
}