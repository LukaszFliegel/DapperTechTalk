using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApi.EF.Models;
using Dapper;

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
            //var purchaseInvoices = await _dbContext.PurchaseInvoices
            //    .Include(pi => pi.Contractor)
            //    .Include(pi => pi.PaymentMethod)
            //    .Where(pi => pi.FirmId == firmId && pi.FinancialYearId == financialYearId)
            //    .ToListAsync();

            var sql = @"
                    SELECT
                        pi.Id, pi.FirmId, pi.FinancialYearId, pi.InvoiceNumber, pi.InnerInvoiceNumber, pi.InvoiceDate, pi.PaymentDate, pi.Description, pi.ContractorId,
                        pi.PaymentMethodId, pi.IsAdvancePayment, pi.PurchaseDate,
                        c.Id, c.FirmId, c.ContractorCode, c.ContractorName, c.NIP, c.Street, c.City, c.ApartmentNumber, c.Country, c.ZipNumber, c.BankAccountNumber, c.IsDefault, c.ParentContractorId, c.IsVatPayer,
                        pm.Id, pm.FirmId, pm.PaymentMethodCode, pm.PaymentMethodName, pm.IsDefault
                    FROM
                        PurchaseInvoices pi
                        INNER JOIN Contractors c on c.id = pi.ContractorId
                        INNER JOIN PaymentMethods pm on pm.Id = pi.PaymentMethodId
                    WHERE
                        pi.FirmId = @firmId
	                    AND pi.FinancialYearId = @financialYearId";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                var purchaseInvoices = await connection.QueryAsync<PurchaseInvoice, Contractor, PaymentMethod, PurchaseInvoice>(
                    sql,
                    (purchaseInvoice, contractor, paymentMethod) =>
                    {
                        purchaseInvoice.Contractor = contractor;
                        purchaseInvoice.PaymentMethod = paymentMethod;
                        return purchaseInvoice;
                    },
                    new { firmId, financialYearId },
                    splitOn: "Id");

                return Ok(purchaseInvoices);
            }                        
        }
    }
}
