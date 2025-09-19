using Microsoft.AspNetCore.Mvc;
using NewBankingProject_1.Services;
using System;
using System.Threading.Tasks;

namespace NewBankingProject_1.Controllers
{
    [ApiController]
    [Route("api/accounts/{accountId}/[controller]")]
    public class StatementsController : ControllerBase
    {
        private readonly IStatementService _service;
        public StatementsController(IStatementService service) { _service = service; }

  
        [HttpGet]
        public async Task<IActionResult> GetStatement(int accountId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var dto = await _service.GetStatementAsync(accountId, startDate, endDate);
                return Ok(dto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        
        [HttpGet("export")]
        public async Task<IActionResult> Export(int accountId, DateTime startDate, DateTime endDate, string format = "excel")
        {
            try
            {
                if (format.Equals("excel", StringComparison.OrdinalIgnoreCase))
                {
                    var bytes = await _service.GenerateExcelAsync(accountId, startDate, endDate);
                    return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"statement_{accountId}.xlsx");
                }
                else if (format.Equals("pdf", StringComparison.OrdinalIgnoreCase))
                {
                    var bytes = await _service.GeneratePdfAsync(accountId, startDate, endDate);
                    return File(bytes, "application/pdf", $"statement_{accountId}.pdf");
                }

                return BadRequest("Unsupported format. Use 'excel' or 'pdf'.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
