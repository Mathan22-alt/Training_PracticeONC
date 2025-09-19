using Microsoft.AspNetCore.Mvc;
using NewBankProject.Data;
using NewBankProject.Models;

namespace NewBankProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly BankingContext _context;

        public AccountsController(BankingContext context)
        {
            _context = context;
        }

        [HttpPost("Create")]
        public IActionResult CreateAccount([FromBody] Account account)
        {
            if (account == null)
                return BadRequest("Account data is required.");

            _context.Accounts.Add(account);
            _context.SaveChanges();

            return Ok(account);
        }

        [HttpGet]
        public IActionResult GetAccounts()
        {
            return Ok(_context.Accounts.ToList());
        }
    }
}
