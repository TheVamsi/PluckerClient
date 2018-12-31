using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PluckerClient.Models
{
    public partial class em_portContext : DbContext
    {
        public em_portContext()
        {
        }

        public em_portContext(DbContextOptions<em_portContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientColumn> ClientColumn { get; set; }
        public virtual DbSet<ClientCountry> ClientCountry { get; set; }
        public virtual DbSet<ClientCountryCustom> ClientCountryCustom { get; set; }
        public virtual DbSet<ClientDocClassExclusion> ClientDocClassExclusion { get; set; }
        public virtual DbSet<ClientIndustry> ClientIndustry { get; set; }
        public virtual DbSet<ClientIndustryCustom> ClientIndustryCustom { get; set; }
        public virtual DbSet<ClientSector> ClientSector { get; set; }
        public virtual DbSet<ClientSectorIndustryCustom> ClientSectorIndustryCustom { get; set; }
        public virtual DbSet<ClientSourceCodes> ClientSourceCodes { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Industry> Industry { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=eurodev2;Initial Catalog=em_port;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client", "PluckerClients");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.GetsPdf).HasColumnName("GetsPDF");

                entity.Property(e => e.GetsPpt).HasColumnName("GetsPPT");

                entity.Property(e => e.GetsWordLoc).HasColumnName("GetsWordLOC");

                entity.Property(e => e.GetsXml).HasColumnName("GetsXML");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrackingArgument)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZipfileName)
                    .HasColumnName("ZIPFileName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientColumn>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.ColumnId })
                    .HasName("PK_PluckerClientsClientColumn");

                entity.ToTable("ClientColumn", "PluckerClients");
            });

            modelBuilder.Entity<ClientCountry>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.CountryCode })
                    .HasName("PK_PluckerClientsClientCountry");

                entity.ToTable("ClientCountry", "PluckerClients");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientCountryCustom>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.ImiscountryCode })
                    .HasName("PK_PluckerClientsClientCountryCustom");

                entity.ToTable("ClientCountryCustom", "PluckerClients");

                entity.Property(e => e.ImiscountryCode)
                    .HasColumnName("IMISCountryCode")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCustom)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientDocClassExclusion>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.ProjectCode, e.DocClassId })
                    .HasName("PK_PluckerClientsClientDocClassExclusion");

                entity.ToTable("ClientDocClassExclusion", "PluckerClients");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientIndustry>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.IndustryCode })
                    .HasName("PK_PluckerClientsClientIndustry");

                entity.ToTable("ClientIndustry", "PluckerClients");

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientIndustryCustom>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.IndustryCode })
                    .HasName("PK_PluckerClientsClientIndustryCustom");

                entity.ToTable("ClientIndustryCustom", "PluckerClients");

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IndustryCustom)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientSector>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.IndustryCode, e.SectorName })
                    .HasName("PK_PluckerClientsClientSector");

                entity.ToTable("ClientSector", "PluckerClients");

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SectorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientSectorIndustryCustom>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.IndustryCode, e.SectorName })
                    .HasName("PK_PluckerClientsClientSectorIndustryCustom");

                entity.ToTable("ClientSectorIndustryCustom", "PluckerClients");

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SectorName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IndustryCustom)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientSourceCodes>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.SourceCode })
                    .HasName("PK_PluckerClientsClientSourceCodes");

                entity.ToTable("ClientSourceCodes", "PluckerClients");

                entity.Property(e => e.SourceCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SourceName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryCodeId);

                entity.HasIndex(e => e.CountryCode)
                    .HasName("UQ_Country_CountryCode")
                    .IsUnique();

                entity.HasIndex(e => e.ImiscountryCode)
                    .HasName("idx_Country_IMISCountryCode");

                entity.HasIndex(e => new { e.CountryName, e.CountryCodeId })
                    .HasName("IX_Country_CountryCodeID");

                entity.HasIndex(e => new { e.CountryName, e.IsCountry });

                entity.HasIndex(e => new { e.Cclass, e.IsCountry, e.ImiscountryCode });

                entity.HasIndex(e => new { e.CountryName, e.ImiscountryCode, e.Parent, e.Cclass, e.CountryCodeId })
                    .HasName("IX_Country_CountryName_IMISCountryCode_Parent_CClass_CountryCodeID");

                entity.HasIndex(e => new { e.CountryName, e.CountryShortName, e.RegionCode, e.Nmaorder, e.Ccaorder, e.GroupingLevel, e.IsMdcountry, e.IsCountry, e.IsDeveloped, e.IsImiscountry, e.IsClcountry, e.Currency, e.Parent, e.PhoneCode, e.ReportSortOrder, e.OnlineNo, e.InternetSuffix, e.AddressFormat, e.Cclass, e.CountryCodeId, e.IsSeasonal, e.IsoAlpha2Code, e.IsoAlpha3Code, e.IsoNumericCode, e.CountryCode })
                    .HasName("IX_Country_CountryCode");

                entity.HasIndex(e => new { e.CountryName, e.CountryShortName, e.RegionCode, e.Nmaorder, e.Ccaorder, e.GroupingLevel, e.IsMdcountry, e.IsCountry, e.IsDeveloped, e.IsImiscountry, e.IsClcountry, e.Currency, e.Parent, e.PhoneCode, e.ReportSortOrder, e.OnlineNo, e.InternetSuffix, e.AddressFormat, e.Cclass, e.CountryCodeId, e.IsSeasonal, e.IsoAlpha2Code, e.IsoAlpha3Code, e.IsoNumericCode, e.ImiscountryCode })
                    .HasName("IX_Country_IMISCountryCode");

                entity.Property(e => e.CountryCodeId).ValueGeneratedNever();

                entity.Property(e => e.Ccaorder).HasColumnName("CCAOrder");

                entity.Property(e => e.Cclass)
                    .HasColumnName("CClass")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryShortName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImiscountryCode)
                    .IsRequired()
                    .HasColumnName("IMISCountryCode")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.InternetSuffix)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IsClcountry).HasColumnName("IsCLCountry");

                entity.Property(e => e.IsImiscountry).HasColumnName("IsIMISCountry");

                entity.Property(e => e.IsMdcountry).HasColumnName("IsMDCountry");

                entity.Property(e => e.IsoAlpha2Code)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IsoAlpha3Code)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Nmaorder).HasColumnName("NMAOrder");

                entity.Property(e => e.Parent)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.HasKey(e => e.IndustryCode);

                entity.HasIndex(e => e.IndustryName);

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryGroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IndustryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsGmidindustry).HasColumnName("IsGMIDIndustry");

                entity.Property(e => e.IsImisindustry).HasColumnName("IsIMISIndustry");

                entity.Property(e => e.Notes)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.SortOrder).HasDefaultValueSql("((99))");
            });
        }
    }
}
