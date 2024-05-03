using FinallChallenge.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinallChallenge.Controllers
{
    // Controller for handling API requests related to sales territories.
    [Route("api/[controller]")]
    [ApiController]
    public class SalesTerritoryController : ControllerBase
    {
        // A service that provides data access operations for sales territories.
        private readonly ISaleTerritoryService _SalesTerritoryService;

        // Constructor that injects the sales territory service into the controller.
        public SalesTerritoryController(ISaleTerritoryService salesTerritoryService)
        {
            _SalesTerritoryService = salesTerritoryService;
        }

        // HTTP GET method to retrieve a list of all sales territories.
        // This endpoint responds to 'GET api/SalesTerritory' requests.
        [HttpGet]
        public async Task<IActionResult> GetSalesTerritories()
        {
            try
            {
                // Retrieves all sales territories using the service.
                var SalesTerritories = await _SalesTerritoryService.GetSalesTerritories();
                // Returns a 200 OK status code with the list of sales territories.
                return Ok(SalesTerritories);
            }
            catch (Exception ex)
            {
                // Returns a 500 Internal Server Error status code with the exception message in case of failure.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
