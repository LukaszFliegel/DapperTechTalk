using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class Compensation
    {
        public Compensation()
        {
            CompensationPositions = new HashSet<CompensationPosition>();
        }

        public int Id { get; set; }
        public int FirmId { get; set; }
        public int FinancialYearId { get; set; }
        public int ContractorId { get; set; }
        public string CompensationNumber { get; set; } = null!;
        public DateTime CompensationDate { get; set; }

        public virtual FinancialYear FinancialYear { get; set; } = null!;
        public virtual Firm Firm { get; set; } = null!;
        public virtual ICollection<CompensationPosition> CompensationPositions { get; set; }
    }
}
