using System;
using System.Collections.Generic;

namespace PluckerClient.Models
{
    public partial class Country
    {
        public string ImiscountryCode { get; set; }
        public string CountryName { get; set; }
        public string CountryShortName { get; set; }
        public short? RegionCode { get; set; }
        public short? Nmaorder { get; set; }
        public short? Ccaorder { get; set; }
        public short? GroupingLevel { get; set; }
        public bool IsMdcountry { get; set; }
        public bool IsCountry { get; set; }
        public bool IsDeveloped { get; set; }
        public bool IsImiscountry { get; set; }
        public bool IsClcountry { get; set; }
        public string Currency { get; set; }
        public string Parent { get; set; }
        public string PhoneCode { get; set; }
        public short? ReportSortOrder { get; set; }
        public int? OnlineNo { get; set; }
        public string InternetSuffix { get; set; }
        public int? AddressFormat { get; set; }
        public string Cclass { get; set; }
        public short CountryCodeId { get; set; }
        public bool IsSeasonal { get; set; }
        public string IsoAlpha2Code { get; set; }
        public string IsoAlpha3Code { get; set; }
        public short? IsoNumericCode { get; set; }
        public string CountryCode { get; set; }
    }
}
