using FinallChallenge.Domain.Interfaces;
using FinallChallenge.Domain.Models;
using FinallChallenge.Infraestructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinallChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReportsController: ControllerBase
    {
        private readonly ISalesService _salesreport;

        public SalesReportsController(ISalesService salesreport)
        {
            _salesreport = salesreport;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalesData([FromQuery] string categoryFilter, [FromQuery] string? regionFilter, [FromQuery] string? StartDate, [FromQuery] string? EndDate, [FromQuery] int? page, [FromQuery] int? pageSize)
        {
            try
            {
                var salesData = await _salesreport.GetSalesDataByFilterAsync(categoryFilter, regionFilter, StartDate, EndDate, page, pageSize);
                return Ok(salesData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
