using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi.EF.Models;

namespace WebApi.EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly DapperTechTalkDbContext _dbContext;

        public BankAccountsController(DapperTechTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll([Required] int firmId)
        {
            var bankAccounts = from ba in _dbContext.BankAccounts
            where ba.FirmId == firmId
            select ba;

            return Ok(bankAccounts);
        }
    }
}
