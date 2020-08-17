#region Using Statements
using Company.SampleApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
#endregion

namespace Company.SampleApp.Data.Ef
{
    public partial class AppDbContext
    {
        public void MapChildResource(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<ChildResource> t = modelBuilder.Entity<ChildResource>();

            // t.ToTable("ChildResources");

            t.HasKey(x => x.Id);

            // Properties
            t.Property(p => p.Name)
            // .HasMaxLength(255)
            .HasColumnType("varchar(255)")
            ;

            // Indexes
            t.HasIndex(p => p.Name);

            // Relationships and Navigation


        }

    }

}
