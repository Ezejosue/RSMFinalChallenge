namespace FinallChallenge.Domain.Models
{
    public class SaleReport
    {
        public string? ProductName { get; set; }
        public string? ProductCategory { get; set; }
        public decimal TotalSales { get; set; }
        public decimal PercentContributionByCategoryAndRegion { get; set; }
        public decimal PercentContributionByRegion { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
