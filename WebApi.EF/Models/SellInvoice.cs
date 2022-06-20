using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class SellInvoice
    {
        public SellInvoice()
        {
            CompensationPositions = new HashSet<CompensationPosition>();
            InverseCorrectionInvoice = new HashSet<SellInvoice>();
            SellInvoicePayments = new HashSet<SellInvoicePayment>();
            SellInvoicePositions = new HashSet<SellInvoicePosition>();
        }

        public int Id { get; set; }
        public int FirmId { get; set; }
        public int FinancialYearId { get; set; }
        public string InvoiceNumber { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? Description { get; set; }
        public int ContractorId { get; set; }
        public int? InvestmentId { get; set; }
        public int BankAccountId { get; set; }
        public int PaymentMethodId { get; set; }
        public bool IsAdvancePayment { get; set; }
        public DateTime? SellDate { get; set; }
        public int? CorrectionInvoiceId { get; set; }

        public virtual BankAccount BankAccount { get; set; } = null!;
        public virtual Contractor Contractor { get; set; } = null!;
        public virtual SellInvoice? CorrectionInvoice { get; set; }
        public virtual FinancialYear FinancialYear { get; set; } = null!;
        public virtual Firm Firm { get; set; } = null!;
        public virtual Investment? Investment { get; set; }
        public virtual ICollection<CompensationPosition> CompensationPositions { get; set; }
        public virtual ICollection<SellInvoice> InverseCorrectionInvoice { get; set; }
        public virtual ICollection<SellInvoicePayment> SellInvoicePayments { get; set; }
        public virtual ICollection<SellInvoicePosition> SellInvoicePositions { get; set; }
    }
}
