using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using FinallChallenge.DTOs;
using FinallChallenge.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinallChallenge.Services
{
    public class SalesTerritoryService : ISalesTerritoryService
    {
        private readonly ISalesTerritoryRepository _service;

        public SalesTerritoryService(ISalesTerritoryRepository service)
        {
            _service = service;
        }

        public async Task<IEnumerable<GetSalesTerritory>> GetSalesTerritories()
        {
            var SalesTerritories = await _service.GetSalesTerritories();
            List<GetSalesTerritory> salesTerritories = new();

            foreach (var SaleTerritory in SalesTerritories)
            {
                GetSalesTerritory dto = new()
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
