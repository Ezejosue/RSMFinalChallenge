using FinallChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinallChallenge.Infraestructure.Configurations
{
    /// <summary>
    /// Configuration for the SalesTerritory entity.
    /// </summary>
    public class SaleTerritoryConfiguration : IEntityTypeConfiguration<SalesTerritory>
    {
        /// <summary>
        /// Configures the SalesTerritory entity.
        /// </summary>
        /// <param name="builder">The entity type builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<SalesTerritory> builder)
        {
            // Table name and schema
            builder.ToTable(nameof(SalesTerritory), "Sales");

            // Primary key
            builder.HasKey(e => e.TerritoryID);

            // Column mappings
            builder.Property(e => e.TerritoryID).HasColumnName("TerritoryID");
            builder.Property(e => e.Name).IsRequired();
        }
    }
}