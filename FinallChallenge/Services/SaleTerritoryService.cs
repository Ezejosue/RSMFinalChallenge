using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using FinallChallenge.DTOs;

namespace FinallChallenge.Services
{
    /// <summary>
    /// Service for managing sales territories.
    /// </summary>
    public class SaleTerritoryService : ISaleTerritoryService
    {
        private readonly ISaleTerritoryRepository _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleTerritoryService"/> class.
        /// </summary>
        /// <param name="service">The repository for accessing sales territories.</param>
        public SaleTerritoryService(ISaleTerritoryRepository service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves sales territories.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains an enumerable collection of GetSaleTerritoryDto objects.</returns>
        public async Task<IEnumerable<GetSaleTerritoryDto>> GetSalesTerritories()
        {
            var SalesTerritories = await _service.GetSalesTerritories();
            List<GetSaleTerritoryDto> salesTerritories = new();

            foreach (var SaleTerritory in SalesTerritories)
            {
                GetSaleTerritoryDto dto = new()
                {
                    TerritoryID = SaleTerritory.TerritoryID,
                    Name = SaleTerritory.Name
                };
                salesTerritories.Add(dto);
            }

            return salesTerritories;
        }
    }
}
