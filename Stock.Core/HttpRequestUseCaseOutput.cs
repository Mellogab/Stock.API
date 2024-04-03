using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core
{
    public class HttpRequestUseCaseOutput
    {
        public bool Successfully { get; set; } = true;
        public object Error { get; set; }
        public string output { get; set; }
    }
}
