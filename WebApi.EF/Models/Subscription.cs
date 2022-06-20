using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class Subscription
    {
        public Subscription()
        {
            UserSubscriptions = new HashSet<UserSubscription>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int PeriodInMonths { get; set; }
        public decimal PricePerMonth { get; set; }

        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
    }
}
