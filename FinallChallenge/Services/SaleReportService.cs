using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;

namespace FinallChallenge.Services
{
    /// <summary>
    /// Service for retrieving sales data.
    /// </summary>
    public class SaleReportService : ISaleService
    {
        private readonly ISaleRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleReportService"/> class.
        /// </summary>
        /// <param name="repository">The repository for accessing sales data.</param>
        public SaleReportService(ISaleRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves sales data filtered by specified parameters.
        /// </summary>
        /// <param name="categoryFilter">The category by which to filter the sales data.</param>
        /// <param name="regionFilter">Optional parameter specifying the region by which to filter the sales data.</param>
        /// <param name="StartDate">Optional parameter indicating the start date for filtering the sales data.</param>
        /// <param name="EndDate">Optional parameter indicating the end date for filtering the sales data.</param>
        /// <param name="page">Optional parameter indicating the page number for pagination.</param>
        /// <param name="pageSize">Optional parameter specifying the number of items per page for pagination.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a list of SaleReport objects.</returns>
        public async Task<List<SaleReport>> GetSalesDataByFilterAsync(string categoryFilter, string? regionFilter, string? StartDate, string? EndDate, int? page, int? pageSize)
        {
            return await _repository.GetSalesDataByFilterAsync(categoryFilter, regionFilter, StartDate, EndDate, page, pageSize);
        }
    }
}
