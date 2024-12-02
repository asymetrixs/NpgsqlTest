using NpgsqlRowVersion.Models;

namespace NpgsqlRowVersion;

public static class Setup
{
    public static async Task Prepare()
    {
        var dbContextFactory = new TestDbContextFactory();
        await using var dbContext = dbContextFactory.CreateDbContext();
        await dbContext
            .Database
            .EnsureDeletedAsync()
            .ConfigureAwait(false);
        await dbContext
            .Database
            .EnsureCreatedAsync()
            .ConfigureAwait(false);


        await dbContext
            .Xmins
            .AddRangeAsync(Enumerable.Range(1, 50).Select(x => new DboXmin() { Col1 = x }))
            .ConfigureAwait(false);
        await dbContext
            .Xmins
            .AddRangeAsync(Enumerable.Range(1, 50).Select(x => new DboXmin() { Col1 = x }))
            .ConfigureAwait(false);


        await dbContext
            .IsRowVersions
            .AddRangeAsync(Enumerable.Range(1, 50).Select(x => new DboIsRowVersion() { Col1 = x }))
            .ConfigureAwait(false);
        await dbContext
            .IsRowVersions
            .AddRangeAsync(Enumerable.Range(1, 50).Select(x => new DboIsRowVersion() { Col1 = x }))
            .ConfigureAwait(false);


        await dbContext
            .Timestamps
            .AddRangeAsync(Enumerable.Range(1, 50).Select(x => new DboTimestamp() { Col1 = x }))
            .ConfigureAwait(false);
        await dbContext
            .Timestamps
            .AddRangeAsync(Enumerable.Range(1, 50).Select(x => new DboTimestamp() { Col1 = x }))
            .ConfigureAwait(false);

        Console.WriteLine("Added two entities");

        try
        {
            await dbContext
                .SaveChangesAsync()
                .ConfigureAwait(false);

            Console.WriteLine("Saved two entities");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        await dbContext.DisposeAsync().ConfigureAwait(false);
    }
}
