using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class UserFirm
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; } = null!;
        public int FirmId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; } = null!;
        public virtual Firm Firm { get; set; } = null!;
    }
}
