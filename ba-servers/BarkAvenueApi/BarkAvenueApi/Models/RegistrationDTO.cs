using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace BarkAvenueApi.Models
{
    public class RegistrationDTO
    {
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^\w+$", ErrorMessage = "Invalid username format. Use only letters, numbers, or underscore")]
        public string? username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number format. Use 10 digits")]
        public string? phone_number { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? password_user { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        public string? confirm_password { get; set; }
    }

    public class User
    {
        public int user_id { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public string? phone_number { get; set; }
        public string? password_user { get; set; }
        public string? role_user { get; set; }
        public DateTimeOffset date_registration { get; set; }
        public DateTimeOffset last_login { get; set; }

        public bool is_active { get; set; }
        public string? permission_user { get; set; }
    }
    public static class UserMapper
    {
        public static User MapFromRegistrationDTO(RegistrationDTO registrationDTO)
        {
            return new User
            {
                username = registrationDTO.username,
                email = registrationDTO.email,
                phone_number = registrationDTO.phone_number,
                password_user = registrationDTO.password_user
            };
        }
    }
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
