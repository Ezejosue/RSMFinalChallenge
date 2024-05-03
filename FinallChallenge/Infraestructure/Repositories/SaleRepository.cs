using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FinallChallenge.Infraestructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AdvWorksDbContext _context;

        public SaleRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<List<SaleReport>> GetSalesDataByFilterAsync(string categoryFilter, string? regionFilter, string? StartDate, string? EndDate, int? page, int? pageSize)
        {
            var categoryParam = new SqlParameter("@CategoryFilter", categoryFilter ?? (object)DBNull.Value);
            var regionParam = new SqlParameter("@RegionFilter", regionFilter ?? (object)DBNull.Value);
            var StartDateParam = new SqlParameter("@StartDate", StartDate ?? (object)DBNull.Value);
            var EndDateParam = new SqlParameter("@EndDate", EndDate ?? (object)DBNull.Value);
            var pageNumberParam = new SqlParameter("@PageNumber", page ?? (object)DBNull.Value);
            var pageSizeParam = new SqlParameter("@PageSize", pageSize ?? (object)DBNull.Value);

            return await _context.Set<SaleReport>()
             .FromSqlRaw("EXEC GetSalesDataByFilter @CategoryFilter, @RegionFilter, @StartDate, @EndDate, @PageNumber, @PageSize",
                 categoryParam, regionParam, StartDateParam, EndDateParam, pageNumberParam, pageSizeParam)
             .ToListAsync();
        }

    }
}
