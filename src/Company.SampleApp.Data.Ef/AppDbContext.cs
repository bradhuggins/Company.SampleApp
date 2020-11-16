#region Using Statements
using Company.SampleApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
#endregion

//msdn docs...
// https://docs.microsoft.com/en-us/ef/core/

namespace Company.SampleApp.Data.Ef
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        #region Properties
		public DbSet<ChildResource> ChildResources { get; set; }
		public DbSet<Resource> Resources { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			this.MapChildResource(modelBuilder);
			this.MapResource(modelBuilder);

        }

        [ExcludeFromCodeCoverage]
        public void CreateDatabase()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

    }

}
