using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class PurchaseInvoicePosition
    {
        public int Id { get; set; }
        public int PositionNumber { get; set; }
        public int PurchaseInvoiceId { get; set; }
        public decimal UnitPrice { get; set; }
        public int VatRate { get; set; }
        public int? InvestmentId { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int MeasurementUnitId { get; set; }
        public bool IsGross { get; set; }

        public virtual Investment? Investment { get; set; }
        public virtual MeasurementUnit MeasurementUnit { get; set; } = null!;
        public virtual PurchaseInvoice PurchaseInvoice { get; set; } = null!;
    }
}
