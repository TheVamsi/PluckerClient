using System.Collections.Generic;

namespace PluckerClient.Models
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string ZipfileName { get; set; }
        public bool AllIndustries { get; set; }
        public IList<AllowedClientCountries> AllowedClientCountries { get; set;}
        //public IList<string> AllowedClientCountries { get; set; }
        public IList<string> AllowedClientIndustries { get; set; }
        public bool AllCountries { get; set; }
        public bool GetsWord { get; set; }
        public bool GetsPdf { get; set; }
        public bool GetsLoadsheet { get; set; }
        public bool GetsPpt { get; set; }
        public bool GetsControlFiles { get; set; } 

    }
}
