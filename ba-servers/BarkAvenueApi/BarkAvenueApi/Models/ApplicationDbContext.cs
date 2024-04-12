using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

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
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

<<<<<<< HEAD
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=barkavenue;Username=postgres;Password=marta15.02;");
=======
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
>>>>>>> b99e4c353bc150b765db6826dbc7f946ea3bf5fb
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
        }
<<<<<<< HEAD

       

=======
>>>>>>> b99e4c353bc150b765db6826dbc7f946ea3bf5fb
    }
}
