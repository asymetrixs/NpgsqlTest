using Microsoft.EntityFrameworkCore;

namespace NpgsqlRowVersion;

public class TestDbContextFactory : IDbContextFactory<TestDbContext>
{
    public TestDbContext CreateDbContext()
    {
        return new TestDbContext(TestDbContext.GetOptions());
    }
}
