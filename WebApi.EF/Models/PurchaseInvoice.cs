using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class PurchaseInvoice
    {
        public PurchaseInvoice()
        {
            CompensationPositions = new HashSet<CompensationPosition>();
            PurchaseInvoicePayments = new HashSet<PurchaseInvoicePayment>();
            PurchaseInvoicePositions = new HashSet<PurchaseInvoicePosition>();
        }

        public int Id { get; set; }
        public int FirmId { get; set; }
        public int FinancialYearId { get; set; }
        public string InvoiceNumber { get; set; } = null!;
        public string? InnerInvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? Description { get; set; }
        public int ContractorId { get; set; }
        public int PaymentMethodId { get; set; }
        public bool IsAdvancePayment { get; set; }
        public DateTime? PurchaseDate { get; set; }

        public virtual Contractor Contractor { get; set; } = null!;
        public virtual FinancialYear FinancialYear { get; set; } = null!;
        public virtual Firm Firm { get; set; } = null!;
        public virtual ICollection<CompensationPosition> CompensationPositions { get; set; }
        public virtual ICollection<PurchaseInvoicePayment> PurchaseInvoicePayments { get; set; }
        public virtual ICollection<PurchaseInvoicePosition> PurchaseInvoicePositions { get; set; }
    }
}
