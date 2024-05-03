using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using Microsoft.Data.SqlClient;

namespace FinallChallenge.Services
{
    public class SaleReportService : ISaleService
    {
        private readonly ISaleRepository _repository;

        public SaleReportService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SaleReport>> GetSalesDataByFilterAsync(string categoryFilter, string? regionFilter, string? StartDate, string? EndDate, int? page, int? pageSize)
        {
            return await _repository.GetSalesDataByFilterAsync(categoryFilter, regionFilter, StartDate, EndDate, page, pageSize);
        }

    }
}
