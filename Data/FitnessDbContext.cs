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

        public DbSet<Antrenor> Antrenor { get; set; }
        public DbSet<AntHizmet> AntHizmet { get; set; }
        public DbSet<AntMusaitlik> AntMusaitlik { get; set; }
        public DbSet<Hizmet> Hizmet { get; set; }
        public DbSet<HizSalon> HizSalon { get; set; }
        public DbSet<Randevu> Randevu { get; set; }
        public DbSet<Salon> Salon { get; set; }
        public DbSet<Uye> Uye { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AntHizmet>()
                .HasKey(ah => new { ah.AntID, ah.HizID });

            modelBuilder.Entity<HizSalon>()
                .HasKey(hs => new { hs.HizID, hs.SalID });
        }
    }
}
