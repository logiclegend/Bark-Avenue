using Microsoft.EntityFrameworkCore;

namespace BarkAvenueApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public object Users { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=barkavenue;Username=postgres;Password=marta15.02;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.user_id);
        }

       

    }
}
