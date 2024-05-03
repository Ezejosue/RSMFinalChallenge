using FinallChallenge.Domain.Models;

namespace FinallChallenge.Domain.Interfaces
{
    public interface ISaleTerritoryRepository
    {
        Task<IEnumerable<SaleTerritory>> GetSalesTerritories();
    }
}