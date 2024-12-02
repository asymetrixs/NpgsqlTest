// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using NpgsqlRowVersion;

public static class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Row Version tests");

        await Setup.Prepare();

        await XminTest();

        await IsRowVersionTest();

        await TimestampTest();
    }

    private static async Task XminTest()
    {
        var dbFactory = new TestDbContextFactory();

        var dbContext = dbFactory.CreateDbContext();

        // Xmin
        var dboXmin = await dbContext
            .Xmins
            .FirstOrDefaultAsync(c => c.Col1 == 1);

        Console.WriteLine($"Retrieved xmin entity with Col1 = {dboXmin.Col1} and RowVersion = {dboXmin.RowVersion}.");

        dboXmin.Col1 = 2;

        try
        {
            await dbContext
                .SaveChangesAsync()
                .ConfigureAwait(false);

            Console.WriteLine($"Updated xmin entity with Col1 = {dboXmin.Col1} and RowVersion = {dboXmin.RowVersion}.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        await dbContext.DisposeAsync();

        // Clean context
        dbContext = dbFactory.CreateDbContext();

        // Xmin
        try
        {
            var dboXmins = await dbContext
                .Xmins
                .Where(d => d.Col1 == 1)
                .Distinct()
                .ToListAsync();

            Console.WriteLine($"Distinct count: {dboXmins.Count}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            await dbContext.DisposeAsync();
        }
    }

    private static async Task IsRowVersionTest()
    {
        var dbFactory = new TestDbContextFactory();

        var dbContext = dbFactory.CreateDbContext();

        // Xmin
        var dboIsRowVersion = await dbContext
            .IsRowVersions
            .Where(d => d.Col1 == 1)
            .FirstOrDefaultAsync(c => c.Col1 == 1);

        Console.WriteLine(
            $"Retrieved isRowVersion entity with Col1 = {dboIsRowVersion.Col1} and RowVersion = {dboIsRowVersion.RowVersion}.");

        dboIsRowVersion.Col1 = 2;

        try
        {
            await dbContext
                .SaveChangesAsync()
                .ConfigureAwait(false);

            Console.WriteLine(
                $"Updated isRowVersion entity with Col1 = {dboIsRowVersion.Col1} and RowVersion = {dboIsRowVersion.RowVersion}.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        await dbContext.DisposeAsync();

        // Clean context
        dbContext = dbFactory.CreateDbContext();

        // Xmin
        try
        {
            var dboIsRowVersions = await dbContext
                .IsRowVersions
                .Where(d => d.Col1 == 1)
                .Distinct()
                .ToListAsync();

            Console.WriteLine($"Distinct count: {dboIsRowVersions.Count}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            await dbContext.DisposeAsync();
        }
    }

    private static async Task TimestampTest()
    {
        var dbFactory = new TestDbContextFactory();

        var dbContext = dbFactory.CreateDbContext();

        // Xmin
        var dboTimestamp = await dbContext
            .Timestamps
            .FirstOrDefaultAsync(c => c.Col1 == 1);

        Console.WriteLine(
            $"Retrieved timestamp entity with Col1 = {dboTimestamp.Col1} and RowVersion = {dboTimestamp.RowVersion}.");

        dboTimestamp.Col1 = 2;

        try
        {
            await dbContext
                .SaveChangesAsync()
                .ConfigureAwait(false);

            Console.WriteLine(
                $"Updated timestamp entity with Col1 = {dboTimestamp.Col1} and RowVersion = {dboTimestamp.RowVersion}.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        await dbContext.DisposeAsync();

        // Clean context
        dbContext = dbFactory.CreateDbContext();

        // Xmin
        try
        {
            var dboTimestamps = await dbContext
                .Timestamps
                .Where(d => d.Col1 == 1)
                .Distinct()
                .ToListAsync();

            Console.WriteLine($"Distinct count: {dboTimestamps.Count}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            await dbContext.DisposeAsync();
        }
    }
}
