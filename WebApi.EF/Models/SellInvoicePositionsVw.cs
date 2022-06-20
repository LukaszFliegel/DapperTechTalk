using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class SellInvoicePositionsVw
    {
        public int Id { get; set; }
        public int PositionNumber { get; set; }
        public int SellInvoiceId { get; set; }
        public decimal UnitPrice { get; set; }
        public int VatRate { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int MeasurementUnitId { get; set; }
        public bool IsGross { get; set; }
        public decimal? GrossValue { get; set; }
        public decimal? NetValue { get; set; }
        public decimal? VatValue { get; set; }
    }
}
