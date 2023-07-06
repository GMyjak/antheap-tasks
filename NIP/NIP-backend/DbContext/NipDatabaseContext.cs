using Microsoft.EntityFrameworkCore;
using NIP_backend.Model;

namespace NIP_backend.DbContext
{
    public class NipDatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IConfiguration configuration;

        public NipDatabaseContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Entity> Entities { get; set; } = null!;
        public DbSet<EntityPerson> EntityPeople { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("NipDatabaseContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entity>()
                .Property(e => e.AccountNumbers)
                .HasConversion(arr => string.Join(',', arr), str => str.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Entity>()
                .HasMany(e => e.Representatives)
                .WithOne(r => r.EntityAsRepresentative)
                .HasForeignKey(r => r.EntityAsRepresentativeId);

            modelBuilder.Entity<Entity>()
                .HasMany(e => e.AuthorizedClerks)
                .WithOne(r => r.EntityAsClerk)
                .HasForeignKey(r => r.EntityAsClerkId);

            modelBuilder.Entity<Entity>()
                .HasMany(e => e.Partners)
                .WithOne(r => r.EntityAsPartner)
                .HasForeignKey(r => r.EntityAsPartnerId);
        }
    }
}
