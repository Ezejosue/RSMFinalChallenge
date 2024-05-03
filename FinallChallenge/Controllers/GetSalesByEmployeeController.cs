using FinallChallenge.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinallChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSalesByEmployeeController : ControllerBase
    {
        private readonly ISalesByEmployeeService _salesByEmployeeService;

        public GetSalesByEmployeeController(ISalesByEmployeeService service)
        {
            _salesByEmployeeService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalesByeEmployeeAsync([FromQuery] string? startDate, [FromQuery] string? endDate, [FromQuery] string? employee, [FromQuery] string? product, int? page, int? pageSize) 
        {
            try
            {
                var SalesByEmplooyee = await _salesByEmployeeService.GetSalesByEmployee(startDate, endDate, employee, product, page, pageSize);
                return Ok(SalesByEmplooyee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
