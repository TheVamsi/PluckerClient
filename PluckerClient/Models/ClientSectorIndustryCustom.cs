using System;
using System.Collections.Generic;

namespace PluckerClient.Models
{
    public partial class ClientSectorIndustryCustom
    {
        public int ClientId { get; set; }
        public string IndustryCode { get; set; }
        public string SectorName { get; set; }
        public string IndustryCustom { get; set; }
    }
}
