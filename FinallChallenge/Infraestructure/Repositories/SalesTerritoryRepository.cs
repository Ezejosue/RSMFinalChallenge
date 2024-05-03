using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinallChallenge.Infraestructure.Repositories
{
    public class SalesTerritoryRepository : ISalesTerritoryRepository
    {
        private readonly AdvWorksDbContext _context;

        public SalesTerritoryRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesTerritory>> GetSalesTerritories()
        {

            return await _context.Set<SalesTerritory>().AsNoTracking().ToListAsync();
        }
    }
}
