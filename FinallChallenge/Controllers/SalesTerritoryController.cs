using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinallChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesTerritoryController : ControllerBase
    {
        private readonly ISaleTerritoryService _SalesTerritoryService;

        public SalesTerritoryController(ISaleTerritoryService salesTerritoryService)
        {
            _SalesTerritoryService = salesTerritoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalesTerritories()
        {
            try
            {
                var SalesTerritories = await _SalesTerritoryService.GetSalesTerritories();
                return Ok(SalesTerritories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
