namespace EliteABP.Develop.Data;
public interface INovelDbSchemaMigrator
{
    Task MigrateAsync();
}