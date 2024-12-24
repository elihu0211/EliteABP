using EliteABP.Develop.Authors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EliteABP.Develop.Mappings.Authors;
public class AuthorMap : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable(nameof(Author));
        builder.ConfigureByConvention();

        builder.Property(x => x.Name)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(100);
    }
}