using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class UnpaidPurchaseInvoicesVw
    {
        public int Id { get; set; }
        public int FirmId { get; set; }
        public int FinancialYearId { get; set; }
        public string InvoiceNumber { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public int ContractorId { get; set; }
        public string ContractorCode { get; set; } = null!;
        public decimal? GrossValue { get; set; }
        public decimal PaidValue { get; set; }
        public decimal? CompensatedValue { get; set; }
        public decimal? UnpaidValue { get; set; }
    }
}
