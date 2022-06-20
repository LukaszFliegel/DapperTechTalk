namespace WebApi.Dapper.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }

        public int FirmId { get; set; }

        public string? PaymentMethodCode { get; set; }

        public string? PaymentMethodName { get; set; }

        public bool IsDefault { get; set; }
    }
}
