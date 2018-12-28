using System;
using System.Collections.Generic;

namespace PluckerClient.Models
{
    public partial class ClientDocClassExclusion
    {
        public int ClientId { get; set; }
        public string ProjectCode { get; set; }
        public int DocClassId { get; set; }
    }
}
