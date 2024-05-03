namespace FinallChallenge.Domain.Models
{
    /// <summary>
    /// Represents a sales report.
    /// </summary>
    public class SaleReport
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string? ProductName { get; set; }

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        public string? ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets the total sales amount.
        /// </summary>
        public decimal TotalSales { get; set; }

        /// <summary>
        /// Gets or sets the percentage contribution by category and region.
        /// </summary>
        public decimal PercentContributionByCategoryAndRegion { get; set; }

        /// <summary>
        /// Gets or sets the percentage contribution by region.
        /// </summary>
        public decimal PercentContributionByRegion { get; set; }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        public DateTime OrderDate { get; set; }
    }
}
