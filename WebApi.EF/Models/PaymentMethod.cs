using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            PurchaseInvoices = new HashSet<PurchaseInvoice>();
        }

        public int Id { get; set; }
        public int FirmId { get; set; }
        public string PaymentMethodCode { get; set; } = null!;
        public string? PaymentMethodName { get; set; }
        public bool IsDefault { get; set; }

        public virtual Firm Firm { get; set; } = null!;
        public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }
    }
}
