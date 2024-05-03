using FinallChallenge.Domain.Models;

namespace FinallChallenge.Domain.Interfaces
{
    /// <summary>
    /// Interface for accessing sales territories from a repository.
    /// </summary>
    public interface ISaleTerritoryRepository
    {
        /// <summary>
        /// Retrieves sales territories from the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains an enumerable collection of SalesTerritory objects.</returns>
        Task<IEnumerable<SalesTerritory>> GetSalesTerritories();
    }
}