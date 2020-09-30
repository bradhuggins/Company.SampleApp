#region Using Statements
using Microsoft.EntityFrameworkCore;
using System;
#endregion

namespace Company.SampleApp.Data.Ef.Tests
{
    public class NullDbContext : AppDbContext
    {
        public NullDbContext(DbContextOptions<NullDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
