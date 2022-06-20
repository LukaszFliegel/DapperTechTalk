using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class MeasurementUnit
    {
        public MeasurementUnit()
        {
            PurchaseInvoicePositions = new HashSet<PurchaseInvoicePosition>();
            SellInvoicePositions = new HashSet<SellInvoicePosition>();
        }

        public int Id { get; set; }
        public int FirmId { get; set; }
        public string MeasurementUnitCode { get; set; } = null!;
        public string? MeasurementUnitName { get; set; }
        public bool IsDefault { get; set; }

        public virtual Firm Firm { get; set; } = null!;
        public virtual ICollection<PurchaseInvoicePosition> PurchaseInvoicePositions { get; set; }
        public virtual ICollection<SellInvoicePosition> SellInvoicePositions { get; set; }
    }
}
