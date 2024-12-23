﻿using EliteABP.Develop.DbMigrator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
{
    services.AddHostedService<DbMigratorHostedService>();
}).RunConsoleAsync();