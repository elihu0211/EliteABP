using EliteABP.Develop.Categories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EliteABP.Develop.Mappings.Categories;
public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // 資料表名稱
        builder.ToTable(nameof(Category));

        // 自動套用 ABP 的約定和配置，從而簡化模型配置的過程。
        builder.ConfigureByConvention();

        builder.Property(x => x.Name)
            .HasMaxLength(10)
            .IsRequired();
    }
}