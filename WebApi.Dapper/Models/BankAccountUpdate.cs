namespace WebApi.Dapper.Models
{
    public class BankAccountUpdate
    {
        public int FirmId { get; set; }

        public string? BankAccountCode { get; set; }

        public string? BankAccountName { get; set; }

        public string? BankAccountNumber { get; set; }

        public bool IsDefault { get; set; }

        public string? BankName { get; set; }
    }
}
