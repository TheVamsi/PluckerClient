using System;
using System.Collections.Generic;

namespace PluckerClient.Models
{
    public partial class ClientSourceCodes
    {
        public int ClientId { get; set; }
        public int Dollar { get; set; }
        public string SourceCode { get; set; }
        public string SourceName { get; set; }
    }
}
