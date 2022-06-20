namespace WebApi.Dapper.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        public int FirmId { get; set; }

        public string? BankAccountCode { get; set; }

        public string? BankAccountName { get; set; }

        public string? BankAccountNumber { get; set; }

        public bool IsDefault { get; set; }

        public string? BankName { get; set; }
    }
}
