using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class Investment
    {
        public Investment()
        {
            PurchaseInvoicePositions = new HashSet<PurchaseInvoicePosition>();
            SellInvoices = new HashSet<SellInvoice>();
        }

        public int Id { get; set; }
        public int FirmId { get; set; }
        public string InvestmentNumber { get; set; } = null!;
        public string? ContractNumber { get; set; }
        public int InvestmentTypeId { get; set; }
        public string? Description { get; set; }
        public bool IsDefault { get; set; }

        public virtual Firm Firm { get; set; } = null!;
        public virtual InvestmentType InvestmentType { get; set; } = null!;
        public virtual ICollection<PurchaseInvoicePosition> PurchaseInvoicePositions { get; set; }
        public virtual ICollection<SellInvoice> SellInvoices { get; set; }
    }
}
