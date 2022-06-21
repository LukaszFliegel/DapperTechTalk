using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi.Dapper.Models;

namespace WebApi.Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseInvoicesController : ControllerBase
    {
        private readonly IDbConnectionProvider _dbConnectionProvider;

        public PurchaseInvoicesController(IDbConnectionProvider dbConnectionProvider)
        {
            _dbConnectionProvider = dbConnectionProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([Required] int firmId, [Required] int financialYearId)
        {
            List<PurchaseInvoice> purchaseInvoces = null;

            return Ok(purchaseInvoces);
        }
    }
}
