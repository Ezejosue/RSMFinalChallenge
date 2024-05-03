namespace FinallChallenge.Domain.Models
{
    public class SaleByEmployee
    {
        public string? EmployeeName { get; set; }
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public int SalesCount { get; set; }
        public decimal AvgUnitPrice { get; set; }
        public decimal TotalSales { get; set; }
        public DateTime FirstSaleDate { get; set; }
        public DateTime LastSaleDate { get; set; }
    }
}
