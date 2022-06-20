using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class CompensationPosition
    {
        public int Id { get; set; }
        public int CompensationId { get; set; }
        public int ContractorId { get; set; }
        public int PurchaseInvoiceId { get; set; }
        public int SellInvoiceId { get; set; }
        public decimal Value { get; set; }

        public virtual Compensation Co { get; set; } = null!;
        public virtual PurchaseInvoice PurchaseInvoice { get; set; } = null!;
        public virtual SellInvoice SellInvoice { get; set; } = null!;
    }
}
