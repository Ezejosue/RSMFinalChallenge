using FinallChallenge.Domain.Models;
using FinallChallenge.DTOs;

namespace FinallChallenge.Domain.Interfaces
{
    public interface ISalesTerritoryService
    {
        Task<IEnumerable<GetSalesTerritory>> GetSalesTerritories();
    }
}