using FinallChallenge.Domain.Models;
using Microsoft.Data.SqlClient;

namespace FinallChallenge.Domain.Interfaces
{
    public interface ISalesService
    {
       Task<List<SalesReport>> GetSalesDataByFilterAsync(string categoryFilter, string? regionFilter, string? StartDate, string? EndDate, int? page, int? pageSize);
    }
}
