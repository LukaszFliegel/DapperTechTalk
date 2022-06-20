using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class InvestmentType
    {
        public InvestmentType()
        {
            Investments = new HashSet<Investment>();
        }

        public int Id { get; set; }
        public int FirmId { get; set; }
        public string InvestmentTypeCode { get; set; } = null!;
        public string? InvestmentTypeName { get; set; }
        public bool IsDefault { get; set; }

        public virtual Firm Firm { get; set; } = null!;
        public virtual ICollection<Investment> Investments { get; set; }
    }
}
