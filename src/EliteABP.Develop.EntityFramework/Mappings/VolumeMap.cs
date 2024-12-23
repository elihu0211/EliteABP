using EliteABP.Develop.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EliteABP.Develop.Mappings;
public class VolumeMap : IEntityTypeConfiguration<Volume>
{
    public void Configure(EntityTypeBuilder<Volume> builder)
    {
        // 資料表名稱
        builder.ToTable(nameof(Volume));

        // 自動套用 ABP 的約定和配置，從而簡化模型配置的過程。
        builder.ConfigureByConvention();

        builder.Property(x => x.Title)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(100);
    }
}