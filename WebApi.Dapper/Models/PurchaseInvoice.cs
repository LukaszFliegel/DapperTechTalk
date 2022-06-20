namespace WebApi.Dapper.Models
{
    public class PurchaseInvoice
    {
        public int Id { get; set; }

        public int FirmId { get; set; }

        public int FinancialYearId { get; set; }

        public string? InvoiceNumber { get; set; }

        public string? InnerInvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime PaymentDate { get; set; }

        public string? Description { get; set; }

        public int ContractorId { get; set; }

        public int PaymentMethodId { get; set; }

        public bool IsAdvancePayment { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public decimal GrossValue { get; set; }

        public decimal NetValue { get; set; }

        public decimal VatValue { get; set; }

        public Contractor? Contractor { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }
    }
}
