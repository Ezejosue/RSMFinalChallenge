using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using Microsoft.Data.SqlClient;

namespace FinallChallenge.Services
{
    public class SaleReportService : ISalesService
    {
        private readonly ISalesRepository _repository;

        public SaleReportService(ISalesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SalesReport>> GetSalesDataByFilterAsync(string categoryFilter, string? regionFilter, string? StartDate, string? EndDate, int? page, int? pageSize)
        {
            return await _repository.GetSalesDataByFilterAsync(categoryFilter, regionFilter, StartDate, EndDate, page, pageSize);
        }

    }
}
