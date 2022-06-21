using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApi.EF.Models;

namespace WebApi.EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseInvoicesController : ControllerBase
    {
        private readonly DapperTechTalkDbContext _dbContext;

        public PurchaseInvoicesController(DapperTechTalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([Required] int firmId, [Required] int financialYearId)
        {
            var purchaseInvoices = await _dbContext.PurchaseInvoices
                .Include(pi => pi.Contractor)
                .Include(pi => pi.PaymentMethod)
                .Where(pi => pi.FirmId == firmId && pi.FinancialYearId == financialYearId)
                .ToListAsync();

            return Ok(purchaseInvoices);                       
        }
    }
}
