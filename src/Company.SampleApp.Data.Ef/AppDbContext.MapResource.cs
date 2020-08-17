#region Using Statements
using Company.SampleApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
#endregion

namespace Company.SampleApp.Data.Ef
{
    public partial class AppDbContext
    {
        public void MapResource(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Resource> t = modelBuilder.Entity<Resource>();

            // t.ToTable("Resources");

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
