﻿using Microsoft.EntityFrameworkCore;

namespace BarkAvenueApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BarkAvenue;Username=postgres;Password=2005;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.user_id);
        }

    }
}
