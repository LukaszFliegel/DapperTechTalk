using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class CostsOnInvestmentsVw
    {
        public int FirmId { get; set; }
        public int FinancialYearId { get; set; }
        public int? InvestmentId { get; set; }
        public string InvestmentNumber { get; set; } = null!;
        public int InvestmentTypeId { get; set; }
        public string InvestmentTypeCode { get; set; } = null!;
        public string PurchaseInvoiceNumber { get; set; } = null!;
        public DateTime PurchaseInvoiceDate { get; set; }
        public string? PurchaseInvoiceInnerNumber { get; set; }
        public int ContractorId { get; set; }
        public string ContractorCode { get; set; } = null!;
        public string? PurchaseInvoicePositionDescription { get; set; }
        public decimal? GrossValue { get; set; }
        public decimal? NetValue { get; set; }
        public decimal? VatValue { get; set; }
    }
}
