using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class Firm
    {
        public Firm()
        {
            Compensations = new HashSet<Compensation>();
            Contractors = new HashSet<Contractor>();
            FinancialYears = new HashSet<FinancialYear>();
            Investments = new HashSet<Investment>();
            PurchaseInvoices = new HashSet<PurchaseInvoice>();
            SellInvoices = new HashSet<SellInvoice>();
            UserFirms = new HashSet<UserFirm>();
        }

        public int Id { get; set; }
        public string NameShort { get; set; } = null!;
        public string NameFull { get; set; } = null!;
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? HomeNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public long? Nip { get; set; }
        public long? Regon { get; set; }
        public long? Krs { get; set; }

        public virtual InvestmentType InvestmentType { get; set; } = null!;
        public virtual MeasurementUnit MeasurementUnit { get; set; } = null!;
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
        public virtual ICollection<Compensation> Compensations { get; set; }
        public virtual ICollection<Contractor> Contractors { get; set; }
        public virtual ICollection<FinancialYear> FinancialYears { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
        public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }
        public virtual ICollection<SellInvoice> SellInvoices { get; set; }
        public virtual ICollection<UserFirm> UserFirms { get; set; }
    }
}
