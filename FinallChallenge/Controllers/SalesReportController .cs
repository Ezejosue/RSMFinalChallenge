using FinallChallenge.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinallChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReportController: ControllerBase
    {
        private readonly ISaleService _salesreport;

        public SalesReportController(ISaleService salesreport)
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
