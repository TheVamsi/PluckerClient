using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluckerClient.Models
{
    public class AllowedClientIndustries
    {
        public string IndustryCode { get; set; }
        public string IndustryName { get; set; }
        public bool IsImisindustry { get; set; }
        public string Notes { get; set; }
        public bool IsGmidindustry { get; set; }
        public string CategoryGroup { get; set; }
        public short SortOrder { get; set; }

    }
}
