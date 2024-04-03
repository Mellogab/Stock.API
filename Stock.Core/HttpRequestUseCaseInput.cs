using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core
{
    public class HttpRequestUseCaseInput
    {
        public string Uri { get; set; }

        public HttpMethod HttpMethod { get; set; }

        public Dictionary<string, string> Headers { get; set; }
        public string Content { get; set; }
    }
}
