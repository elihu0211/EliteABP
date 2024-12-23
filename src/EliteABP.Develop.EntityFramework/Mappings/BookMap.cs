using EliteABP.Develop.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EliteABP.Develop.Mappings;

public class BookMap : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        // 資料表名稱
        builder.ToTable(nameof(Book));

        // 自動套用 ABP 的約定和配置，從而簡化模型配置的過程。
        builder.ConfigureByConvention();

        builder.Property(x => x.Name)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.AuthorName)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.CategoryName)
            .HasMaxLength(10)
            .IsRequired();
    }
}