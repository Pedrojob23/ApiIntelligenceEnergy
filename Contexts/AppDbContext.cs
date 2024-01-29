using ApiIntelligenceEnergy.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiIntelligenceEnergy.DataContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClientModel> ClientModel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                   => optionsBuilder.UseNpgsql("Host=localhost;Database=intelligenceEnergy;Username=postgres;Password=postgres");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ClientModel>()
            .HasIndex(c => c.Cnpj)
            .IsUnique();

        }
    }
}