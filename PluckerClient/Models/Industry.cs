using System;
using System.Collections.Generic;

namespace PluckerClient.Models
{
    public partial class Industry
    {
        public string IndustryCode { get; set; }
        public string IndustryName { get; set; }
        public bool IsImisindustry { get; set; }
        public string Notes { get; set; }
        public int SequenceBy { get; set; }
        public int? OnlineNo { get; set; }
        public bool Dead { get; set; }
        public bool IsGmidindustry { get; set; }
        public bool IsCustomIndustry { get; set; }
        public short ExpandedLevels { get; set; }
        public short PermissionGroupLevels { get; set; }
        public bool IsFullReport { get; set; }
        public string CategoryGroup { get; set; }
        public short SortOrder { get; set; }
        public bool HasDatagraphics { get; set; }
    }
}
