namespace WebApi.Dapper.Models
{
    public class Investment
    {
        public int Id { get; set; }

        public int FirmId { get; set; }

        public string? InvestmentNumber { get; set; }

        public string? ContractNumber { get; set; }

        public int InvestmentTypeId { get; set; }

        public string? Description { get; set; }

        public bool IsDefault { get; set; }
    }
}
