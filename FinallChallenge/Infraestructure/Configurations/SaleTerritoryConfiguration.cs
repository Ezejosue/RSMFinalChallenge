using FinallChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinallChallenge.Infraestructure.Configurations
{
    public class SaleTerritoryConfiguration : IEntityTypeConfiguration<SaleTerritory>
    {
        public void Configure(EntityTypeBuilder<SaleTerritory> builder)
        {
            builder.ToTable(nameof(SaleTerritory), "Sales");

            builder.HasKey(e => e.TerritoryID);
            builder.Property(e => e.TerritoryID).HasColumnName("TerritoryID");
            builder.Property(e => e.Name).IsRequired();
        }
    }
}