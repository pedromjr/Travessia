using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Competitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Competition Competition { get; set; }

        public bool HasPayment {
            get
            {
                return (Payment != null);
            }
        }
    }
}
