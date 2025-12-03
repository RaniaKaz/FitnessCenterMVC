using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using webProject.Models;
namespace webProject.Data
{
    public class FitnessDbContext : DbContext
    {
        public FitnessDbContext(DbContextOptions<FitnessDbContext> options)
    : base(options)
        {
        }

        public DbSet<Antrenor> Antrenorlar { get; set; }
        public DbSet<AntHizmet> AtrHizmetler { get; set; }
        public DbSet<AntMusaitlik> AtrMusaitlikler { get; set; }
        public DbSet<Hizmet> Hizmetler { get; set; }
        public DbSet<HizSalon> HizSalonlar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Salon> Salonlar { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=FitnessDb;Username=postgres;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AntHizmet>()
                .HasKey(ah => new { ah.AntID, ah.HizID });

            modelBuilder.Entity<HizSalon>()
                .HasKey(hs => new { hs.HizID, hs.SalID });
        }
    }
}
