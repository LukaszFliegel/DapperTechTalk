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
            using(var connection = _dbConnectionProvider.GetConnection())
            {
                var bankAccounts = await connection.QueryAsync<BankAccount>(
                    @"  SELECT * FROM BankAccounts
                        WHERE FirmId = @firmId",
                    new { firmId });

                return Ok(bankAccounts);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BankAccountUpdate bankAccount)
        {
            using (var connection = _dbConnectionProvider.GetConnection())
            {
                var numberOfRowsAffected = await connection.ExecuteAsync(
                    @$"UPDATE BankAccounts SET 
                            FirmId = @FirmId, 
                            BankAccountCode = @BankAccountCode,
                            BankAccountName = @BankAccountName,
                            BankAccountNumber = @BankAccountNumber,
                            IsDefault = @IsDefault,
                            BankName = @BankName
                        WHERE Id = @id",
                        new
                        {
                            bankAccount.FirmId,
                            bankAccount.BankAccountCode,
                            bankAccount.BankAccountName,
                            bankAccount.BankAccountNumber,
                            bankAccount.IsDefault,
                            bankAccount.BankName,
                            id,
                        });

                return NoContent();
            }
        }
    }
}
