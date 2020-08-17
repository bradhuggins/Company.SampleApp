#region Using Statements
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Company.SampleApp.Domain.Models;
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


            //this.MapStringTypeToVarchar(modelBuilder);
            this.TrimStringPropertiesForAllEntities(modelBuilder);
        }

        [ExcludeFromCodeCoverage]
        public void CreateDatabase()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        //public void MapStringTypeToVarchar(ModelBuilder modelBuilder)
        //{
        //    //use varchar for all string fields
        //    foreach (var pb in modelBuilder.Model
        //        .GetEntityTypes()
        //        .SelectMany(t => t.GetProperties())
        //        .Where(p => p.ClrType == typeof(string))
        //        .Select(p => modelBuilder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name)))
        //    {
        //        pb.HasColumnType("varchar(255)");
        //    }
        //}

        public void TrimStringPropertiesForAllEntities(ModelBuilder modelBuilder)
        {
            foreach (var pb in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string))
                .Select(p => modelBuilder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name)))
            {
                pb.HasConversion(
                    new ValueConverter<string,string>(v => v.Trim(), v => v.Trim())
                    );
            }
        }

    }

}
