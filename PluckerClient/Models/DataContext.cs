using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluckerClient.Models
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {

        }
        public virtual DbSet<ClientCountry> Client { get; set; }
        public virtual DbSet<ClientColumn> ClientColumn { get; set; }
        
        public virtual DbSet<ClientCountryCustom> ClientCountryCustom { get; set; }
        public virtual DbSet<ClientDocClassExclusion> ClientDocClassExclusion { get; set; }
        public virtual DbSet<ClientIndustry> ClientIndustry { get; set; }
        public virtual DbSet<ClientIndustryCustom> ClientIndustryCustom { get; set; }
        public virtual DbSet<ClientSector> ClientSector { get; set; }
        public virtual DbSet<ClientSectorIndustryCustom> ClientSectorIndustryCustom { get; set; }
        public virtual DbSet<ClientSourceCodes> ClientSourceCodes { get; set; }

    }
}
