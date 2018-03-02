using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Competitor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string BirthDate { get; set; }
        public List<string> Telephone { get; set; }
        public Payment Payment { get; set; }

        public bool HasPayment {
            get
            {
                return (Payment != null);
            }
        }
    }
}
