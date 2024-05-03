using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinallChallenge.Infraestructure.Repositories
{
    /// <summary>
    /// Repository for accessing sales territories.
    /// </summary>
    public class SaleTerritoryRepository : ISaleTerritoryRepository
    {
        private readonly AdvWorksDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleTerritoryRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public SaleTerritoryRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves sales territories.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains an enumerable collection of SalesTerritory objects.</returns>
        public async Task<IEnumerable<SalesTerritory>> GetSalesTerritories()
        {

            return await _context.Set<SalesTerritory>().AsNoTracking().ToListAsync();
        }
    }
}
