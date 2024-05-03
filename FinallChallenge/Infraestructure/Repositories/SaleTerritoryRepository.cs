using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinallChallenge.Infraestructure.Repositories
{
    public class SaleTerritoryRepository : ISaleTerritoryRepository
    {
        private readonly AdvWorksDbContext _context;

        public SaleTerritoryRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SaleTerritory>> GetSalesTerritories()
        {

            return await _context.Set<SaleTerritory>().AsNoTracking().ToListAsync();
        }
    }
}
