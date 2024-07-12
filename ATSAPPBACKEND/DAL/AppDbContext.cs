using ATSAPPBACKEND.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ATSAPPBACKEND.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<COUNTRY>().ToTable("COUNTRY");
            modelBuilder.Entity<STATE>().ToTable("STATE");
            modelBuilder.Entity<CITY>().ToTable("CITY");
            modelBuilder.Entity<GENDER>().ToTable("GENDER");
            modelBuilder.Entity<VISA>().ToTable("VISA");
            modelBuilder.Entity<WORKNATURE>().ToTable("WORKNATURE");
            modelBuilder.Entity<TAXTERM>().ToTable("TAXTERM");
            modelBuilder.Entity<HYBRIDTYPE>().ToTable("HYBRIDTYPE");
            modelBuilder.Entity<IMPLEMENTATION>().ToTable("IMPLEMENTATION");
            modelBuilder.Entity<CLIENT>().ToTable("CLIENT");
            modelBuilder.Entity<EMPLOYERCOMPANY>().ToTable("EMPLOYERCOMPANY");
            modelBuilder.Entity<EMPLOYER>().ToTable("EMPLOYER");
            modelBuilder.Entity<SUBMISSIONSTATUS>().ToTable("SUBMISSIONSTATUS");
            modelBuilder.Entity<REQUIREMENT>().ToTable("REQUIREMENT");
            modelBuilder.Entity<CANDIDATE>().ToTable("CANDIDATE");
            modelBuilder.Entity<SUBMISSION>().ToTable("SUBMISSION");
            modelBuilder.Entity<REQUIREDVISA>().ToTable("REQUIREDVISA");
        }

        public DbSet<COUNTRY> COUNTRIES { get; set; }
        public DbSet<STATE> STATES { get; set; }
        public DbSet<CITY> CITIES { get; set; }
        public DbSet<GENDER> GENDERS { get; set; }
        public DbSet<VISA> VISAS { get; set; }
        public DbSet<WORKNATURE> WORKNATURES { get; set; }
        public DbSet<TAXTERM> TAXTERMES { get; set; }
        public DbSet<HYBRIDTYPE> HYBRIDTYPES { get; set; }
        public DbSet<IMPLEMENTATION> IMPLEMENTATIONS { get; set; }
        public DbSet<CLIENT> CLIENTS { get; set; }
        public DbSet<EMPLOYERCOMPANY> EMPLOYERCOMPANIES { get; set; }
        public DbSet<EMPLOYER> EMPLOYERS { get; set; }
        public DbSet<SUBMISSIONSTATUS> SUBMISSIONSTATUSES { get; set; }
        public DbSet<REQUIREMENT> REQUIREMENTS { get; set; }
        public DbSet<CANDIDATE> CANDIDATES { get; set; }
        public DbSet<SUBMISSION> SUBMISSIONS { get; set; }
        public DbSet<REQUIREDVISA> REQUIREDVISAS { get; set; }
    }
}
