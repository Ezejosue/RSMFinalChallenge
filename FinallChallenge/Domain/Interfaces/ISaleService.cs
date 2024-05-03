using FinallChallenge.Domain.Models;
using Microsoft.Data.SqlClient;

namespace FinallChallenge.Domain.Interfaces
{
    public interface ISaleService
    {
       Task<List<SaleReport>> GetSalesDataByFilterAsync(string categoryFilter, string? regionFilter, string? StartDate, string? EndDate, int? page, int? pageSize);
    }
}
