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
                        si.Id, si.FirmId, si.FinancialYearId, si.InvoiceNumber, si.InvoiceDate, si.PaymentDate, si.Description, si.ContractorId,
                        si.InvestmentId, si.BankAccountId, si.PaymentMethodId, si.IsAdvancePayment, si.SellDate, si.CorrectionInvoiceId,
	                    sip.GrossValue, sip.NetValue, sip.VatValue,
                        c.Id, c.FirmId, c.ContractorCode, c.ContractorName, c.NIP, c.Street, c.City, c.HomeNumber, c.ApartmentNumber, c.Country, c.ZipNumber, c.BankAccountNumber, c.IsDefault, c.ParentContractorId, c.IsVatPayer,
                        i.Id, i.FirmId, i.InvestmentNumber, i.ContractNumber, i.InvestmentTypeId, i.Description, i.IsDefault,
                        ba.Id, ba.FirmId, ba.BankAccountCode, ba.BankAccountName, ba.BankAccountNumber, ba.IsDefault, ba.BankName,
                        pm.Id, pm.FirmId, pm.PaymentMethodCode, pm.PaymentMethodName, pm.IsDefault
                    FROM
                        SellInvoices si
	                    LEFT JOIN (SELECT SellInvoiceId, SUM(sip.GrossValue) GrossValue, SUM(sip.NetValue) NetValue, SUM(sip.VatValue) VatValue FROM SellInvoicePositions_vw sip GROUP BY SellInvoiceId) sip 
		                    ON sip.SellInvoiceId = si.Id
                        INNER JOIN Contractors c on c.id = si.ContractorId
                        LEFT JOIN Investments i on i.Id = si.InvestmentId
                        INNER JOIN BankAccounts ba on ba.Id = si.BankAccountId
                        INNER JOIN PaymentMethods pm on pm.Id = si.PaymentMethodId
                    WHERE
                        si.FirmId = @firmId 
                        AND si.FinancialYearId = @financialYearId";

                var bankAccounts = await connection.QueryAsync<SellInvoiceList, Contractor, Investment, BankAccount, PaymentMethod, SellInvoiceList>(
                    sql,
                    (sellInvoice, contractor, investment, bankAccount, paymentMethod) =>
                    {
                        sellInvoice.Contractor = contractor;
                        sellInvoice.Investment = investment;
                        sellInvoice.BankAccount = bankAccount;
                        sellInvoice.PaymentMethod = paymentMethod;
                        return sellInvoice;
                    },
                    new { firmId, financialYearId },
                    splitOn: "Id"
                );

                return Ok(bankAccounts);
            }
        }
    }
}
