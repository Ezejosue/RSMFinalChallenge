using FinallChallenge.DTOs;

namespace FinallChallenge.Domain.Interfaces
{
    /// <summary>
    /// Interface for providing sales territory-related services.
    /// </summary>
    public interface ISaleTerritoryService
    {
        /// <summary>
        /// Retrieves sales territories.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains an enumerable collection of GetSaleTerritoryDto objects.</returns>
        Task<IEnumerable<GetSaleTerritoryDto>> GetSalesTerritories();
    }
}