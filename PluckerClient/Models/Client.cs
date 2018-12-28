using System;
using System.Collections.Generic;

namespace PluckerClient.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string ZipfileName { get; set; }
        public string TrackingArgument { get; set; }
        public bool AllIndustries { get; set; }
        public bool AllCountries { get; set; }
        public bool GetsWord { get; set; }
        public bool GetsWordLoc { get; set; }
        public bool GetsPdf { get; set; }
        public bool GetsLoadsheet { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public bool GetsPpt { get; set; }
        public bool GetsControlFiles { get; set; }
        public bool HasClientSector { get; set; }
        public bool GetsXml { get; set; }
        public bool IsActive { get; set; }
    }
}
