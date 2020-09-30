#region Using Statements
using Microsoft.EntityFrameworkCore;
#endregion

namespace Company.SampleApp.Data.Ef.Tests
{
    public class MockDbContext : AppDbContext
    {
        public MockDbContext(DbContextOptions<MockDbContext> options) : base(options)
        {
            new SeedData(this);
        }

    }
}
