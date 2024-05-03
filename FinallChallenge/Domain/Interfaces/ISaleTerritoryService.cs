using FinallChallenge.Domain.Models;
using FinallChallenge.DTOs;

namespace FinallChallenge.Domain.Interfaces
{
    public interface ISaleTerritoryService
    {
        Task<IEnumerable<GetSaleTerritoryDto>> GetSalesTerritories();
    }
}