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
            using (var connection = _dbConnectionProvider.GetConnection())
            {
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

                var purchaseInvoices = await connection.QueryAsync<PurchaseInvoice, Contractor, PaymentMethod, PurchaseInvoice>(
                    sql,
                    (purchaseInvoice, contractor, paymentMethod) =>
                    {
                        purchaseInvoice.Contractor = contractor;
                        purchaseInvoice.PaymentMethod = paymentMethod;
                        return purchaseInvoice;
                    },
                    new { firmId, financialYearId },
                    splitOn: "Id"
                );

                return Ok(purchaseInvoices);
            }
        }
    }
}
