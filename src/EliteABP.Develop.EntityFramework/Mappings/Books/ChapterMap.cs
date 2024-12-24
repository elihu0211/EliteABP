using EliteABP.Develop.Books.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EliteABP.Develop.Mappings.Books;
public class ChapterMap : IEntityTypeConfiguration<Chapter>
{
    public void Configure(EntityTypeBuilder<Chapter> builder)
    {
        // 資料表名稱
        builder.ToTable(nameof(Chapter));

        // 自動套用 ABP 的約定和配置，從而簡化模型配置的過程。
        builder.ConfigureByConvention();

        // 一對一索引
        builder.HasOne(x => x.ChapterText)                      // 一
            .WithOne(x => x.Chapter)                            // 對一
            .HasForeignKey<ChapterText>(ct => ct.ChapterId);    // 外建
    }
}