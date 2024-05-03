using FinallChallenge.Domain.Models;

namespace FinallChallenge.Domain.Interfaces
{
    public interface ISalesTerritoryRepository
    {
        Task<IEnumerable<SalesTerritory>> GetSalesTerritories();
    }
}