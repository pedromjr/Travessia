using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Payment
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public PaymentType Type { get; set; }
    }
}
