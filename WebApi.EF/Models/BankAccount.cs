using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class BankAccount
    {
        public BankAccount()
        {
            SellInvoices = new HashSet<SellInvoice>();
        }

        public int Id { get; set; }
        public int FirmId { get; set; }
        public string BankAccountCode { get; set; } = null!;
        public string BankAccountName { get; set; } = null!;
        public string BankAccountNumber { get; set; } = null!;
        public bool IsDefault { get; set; }
        public string? BankName { get; set; }

        public virtual ICollection<SellInvoice> SellInvoices { get; set; }
    }
}
