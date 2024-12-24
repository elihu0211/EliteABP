using EliteABP.Develop.Books.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EliteABP.Develop.Mappings.Books;
public class ChapterTextMap : IEntityTypeConfiguration<ChapterText>
{
    public void Configure(EntityTypeBuilder<ChapterText> builder)
    {
        // 資料表名稱
        builder.ToTable(nameof(ChapterText));

        // 自動套用 ABP 的約定和配置，從而簡化模型配置的過程。
        builder.ConfigureByConvention();

        builder.Property(x => x.Content)
            .HasColumnType("text")
            .HasMaxLength(8000)
            .IsRequired();

        builder.Property(x => x.AuthorMessage)
            .HasMaxLength(2000);
    }
}