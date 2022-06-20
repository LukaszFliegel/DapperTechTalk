using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class SellInvoicePayment
    {
        public int Id { get; set; }
        public int SellInvoiceId { get; set; }
        public decimal Value { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? Description { get; set; }

        public virtual SellInvoice SellInvoice { get; set; } = null!;
    }
}
