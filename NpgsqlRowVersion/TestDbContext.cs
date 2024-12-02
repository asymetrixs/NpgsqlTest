using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlRowVersion.Models;

namespace NpgsqlRowVersion;

public class TestDbContext : DbContext
{
    public DbSet<DboXmin> Xmins { get; set; }

    public DbSet<DboIsRowVersion> IsRowVersions { get; set; }

    public DbSet<DboTimestamp> Timestamps { get; set; }

    public TestDbContext()
        : base(GetOptions())
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    private static NpgsqlDataSource GetDataSource()
    {
        // Configuration of database context
        var connectionString =
            "Host=localhost;Port=16115;Database=test;Username=abc;Password=123;Include Error Detail=true";
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        return dataSourceBuilder.Build();
    }

    internal static DbContextOptionsBuilder<TestDbContext> GetOptionsBuilder()
    {
        var contextOptionsBuilder = new DbContextOptionsBuilder<TestDbContext>();

        contextOptionsBuilder.UseNpgsql(GetDataSource());
        contextOptionsBuilder.EnableSensitiveDataLogging();

        return contextOptionsBuilder;
    }

    internal static DbContextOptions<TestDbContext> GetOptions() => GetOptionsBuilder().Options;
}
