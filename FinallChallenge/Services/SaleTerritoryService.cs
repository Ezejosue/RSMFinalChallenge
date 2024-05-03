using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using FinallChallenge.DTOs;


namespace FinallChallenge.Services
{
    public class SaleTerritoryService : ISaleTerritoryService
    {
        private readonly ISaleTerritoryRepository _service;

        public SaleTerritoryService(ISaleTerritoryRepository service)
        {
            _service = service;
        }

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
