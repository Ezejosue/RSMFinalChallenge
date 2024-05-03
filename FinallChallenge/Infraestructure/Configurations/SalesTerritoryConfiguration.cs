using FinallChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinallChallenge.Infraestructure.Configurations
{
    public class SalesTerritoryConfiguration : IEntityTypeConfiguration<SalesTerritory>
    {
        public void Configure(EntityTypeBuilder<SalesTerritory> builder)
        {
            builder.ToTable(nameof(SalesTerritory), "Sales");

            builder.HasKey(e => e.TerritoryID);
            builder.Property(e => e.TerritoryID).HasColumnName("TerritoryID");
            builder.Property(e => e.Name).IsRequired();
        }
    }
}