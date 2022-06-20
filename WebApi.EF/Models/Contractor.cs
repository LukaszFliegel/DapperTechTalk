using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class Contractor
    {
        public Contractor()
        {
            PurchaseInvoices = new HashSet<PurchaseInvoice>();
            SellInvoices = new HashSet<SellInvoice>();
        }

        public int Id { get; set; }
        public int FirmId { get; set; }
        public string ContractorCode { get; set; } = null!;
        public string ContractorName { get; set; } = null!;
        public long? Nip { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? HomeNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string? Country { get; set; }
        public string? ZipNumber { get; set; }
        public string? BankAccountNumber { get; set; }
        public bool IsDefault { get; set; }
        public int? ParentContractorId { get; set; }
        public bool IsVatPayer { get; set; }

        public virtual Firm Firm { get; set; } = null!;
        public virtual ICollection<PurchaseInvoice> PurchaseInvoices { get; set; }
        public virtual ICollection<SellInvoice> SellInvoices { get; set; }
    }
}
