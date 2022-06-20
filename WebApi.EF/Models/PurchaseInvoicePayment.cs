using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class PurchaseInvoicePayment
    {
        public int Id { get; set; }
        public int PurchaseInvoiceId { get; set; }
        public decimal Value { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? Description { get; set; }

        public virtual PurchaseInvoice PurchaseInvoice { get; set; } = null!;
    }
}
