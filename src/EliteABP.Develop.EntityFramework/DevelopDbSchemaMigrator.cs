﻿using EliteABP.Develop.Authors.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace EliteABP.Develop;

[Dependency(ServiceLifetime.Transient)]
public class DevelopDbSchemaMigrator(IServiceProvider serviceProvider) : IAuthorDbSchemaMigrator
{
    public async Task MigrateAsync()
    {
        // 執行資料庫遷移
        await serviceProvider.GetRequiredService<DevelopDbContext>().Database.MigrateAsync();
    }
}