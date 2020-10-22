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

            //// Map to a custom table name
            // t.ToTable("CUSTOM_TABLE_NAME");

            //// Definre primary key(s)
            t.HasKey(x => x.Id);

            //// Customize Propertiy Mappings
            t.Property(p => p.Name)
            // .HasColumnName("CUSTOM_COLUMN_NAME") // map property to custom database column name
            // .HasMaxLength(255)
            .HasColumnType("varchar(255)")
            ;


            //// Define Indexes
            t.HasIndex(p => p.Name);

            //// Define Relationships and Navigation


        }

    }

}
