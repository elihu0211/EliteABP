using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace EliteABP.Develop;
public class DevelopDbContextFactory : IDesignTimeDbContextFactory<DevelopDbContext>
{
    public DevelopDbContext CreateDbContext(string[] args)
    {
        var congiguration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<DevelopDbContext>()
            .UseNpgsql(congiguration.GetConnectionString("Develop"),
            optionsBuilder => optionsBuilder.MigrationsAssembly(Assembly.GetExecutingAssembly()));

        return new DevelopDbContext(builder.Options);
    }
    static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false);

        return builder.Build();
    }
}