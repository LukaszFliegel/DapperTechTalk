namespace WebApi.Dapper.Models
{
    public class FinancialYear
    {
        public int Id { get; set; }

        public int FirmId { get; set; }

        public string? FinancialYearName { get; set; }
    }
}
