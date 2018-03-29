using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime SubscriptionLimit { get; set; }
        public decimal SubscriptionValue { get; set; }
        public bool Closed { get; set; }
        public virtual ICollection<Competitor> Competitors { get; set; }
        public Guid CreatorGuid { get; set; }
    }
}
