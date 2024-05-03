using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FinallChallenge.Infraestructure.Repositories
{
    /// <summary>
    /// Repository for accessing sales data.
    /// </summary>
    public class SaleRepository : ISaleRepository
    {
        private readonly AdvWorksDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public SaleRepository(AdvWorksDbContext context)
        {
            _context = context;
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
