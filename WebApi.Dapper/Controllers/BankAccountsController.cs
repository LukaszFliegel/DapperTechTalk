using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi.Dapper.Models;
using Dapper;

namespace WebApi.Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly IDbConnectionProvider _dbConnectionProvider;

        public BankAccountsController(IDbConnectionProvider dbConnectionProvider)
        {
            _dbConnectionProvider = dbConnectionProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([Required] int firmId)
        {
            List<BankAccount> bankAccounts = null;

            return Ok(bankAccounts);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BankAccountUpdate bankAccount)
        {
            return NoContent();
        }
    }
}
