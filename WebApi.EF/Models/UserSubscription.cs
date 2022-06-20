using System;
using System.Collections.Generic;

namespace WebApi.EF.Models
{
    public partial class UserSubscription
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; } = null!;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int SubscriptionId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; } = null!;
        public virtual Subscription Subscription { get; set; } = null!;
    }
}
