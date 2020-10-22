#region Using Statements
using Microsoft.EntityFrameworkCore;
using Company.SampleApp.Data.Ef;
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
