using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NpgsqlRowVersion.Models;

namespace NpgsqlRowVersion.Configurations;

public class DboTimestampConfiguration : IEntityTypeConfiguration<DboXmin>
{
    public void Configure(EntityTypeBuilder<DboXmin> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Col1)
            .IsRequired();
    }
}
