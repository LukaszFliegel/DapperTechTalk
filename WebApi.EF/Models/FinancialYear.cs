using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class FinancialYear
    {
        public FinancialYear()
        {
            Compensations = new HashSet<Compensation>();
            PurchaseInvoices = new HashSet<PurchaseInvoice>();
            SellInvoices = new HashSet<SellInvoice>();
        }

        public int Id { get; set; }
        public int FirmId { get; set; }
        public string FinancialYearName { get; set; } = null!;

        public virtual Firm Firm { get; set; } = null!;
        public virtual ICollection<Compensation> Compensations { get; set; }
        public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }
        public virtual ICollection<SellInvoice> SellInvoices { get; set; }
    }
}
