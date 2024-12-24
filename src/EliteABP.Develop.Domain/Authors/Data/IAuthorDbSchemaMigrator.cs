namespace EliteABP.Develop.Authors.Data;
public interface IAuthorDbSchemaMigrator
{
    Task MigrateAsync();
}