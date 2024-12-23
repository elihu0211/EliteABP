using EliteABP.Develop.Authors;
using EliteABP.Develop.Books;
using EliteABP.Develop.Categories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EliteABP.Develop;

[ConnectionStringName("Develop")]
public class DevelopDbContext(DbContextOptions<DevelopDbContext> options) : AbpDbContext<DevelopDbContext>(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Book> Books { get; set; }
    public DbSet<Volume> Volumes { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<ChapterText> ChapterTexts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 專案內反射實作 IEntityTypeConfiguration<>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}