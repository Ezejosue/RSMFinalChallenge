using FinallChallenge.Domain.Models;

namespace FinallChallenge.Domain.Interfaces
{
    public interface ISalesRepository
    {
        Task<List<SalesReport>> GetSalesDataByFilterAsync(string categoryFilter, string? regionFilter, string? StartDate, string? EndDate, int? page, int? pageSize);

    }
}
