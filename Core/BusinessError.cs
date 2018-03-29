using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class BusinessError
    {
        public string Key { get; set; }

        public string Message { get; set; }

        public Exception ThrownException { get; set; }
    }
}
