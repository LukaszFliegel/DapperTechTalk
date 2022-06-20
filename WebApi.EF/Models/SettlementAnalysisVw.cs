using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class SettlementAnalysisVw
    {
        public string? Key { get; set; }
        public int FirmId { get; set; }
        public int FinancialYearId { get; set; }
        public int ContractorId { get; set; }
        public string ContractorCode { get; set; } = null!;
        public string InvoiceNumber { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal? Owing { get; set; }
        public decimal? Has { get; set; }
    }
}
