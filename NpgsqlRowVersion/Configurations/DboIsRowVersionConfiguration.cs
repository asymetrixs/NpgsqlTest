using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NpgsqlRowVersion.Models;

namespace NpgsqlRowVersion.Configurations;

public class DboIsRowVersionConfiguration : IEntityTypeConfiguration<DboIsRowVersion>
{
    public void Configure(EntityTypeBuilder<DboIsRowVersion> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.RowVersion)
            .IsRowVersion();

        builder.Property(p => p.Col1)
            .IsRequired();
    }
}
