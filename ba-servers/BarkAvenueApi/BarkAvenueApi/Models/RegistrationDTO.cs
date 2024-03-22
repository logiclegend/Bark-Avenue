using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace BarkAvenueApi.Models
{
    public class RegistrationDTO
    {
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^\w+$", ErrorMessage = "Invalid username format. Use only letters, numbers, or underscore")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number format. Use 10 digits")]
        public string? Phone_number { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password_user { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        public string? Confirm_password { get; set; }
    }

    public class User
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string password_user { get; set; }
        public string role_user { get; set; }
        public DateTimeOffset date_registration { get; set; }
        public DateTimeOffset last_login { get; set; }

        public bool is_active { get; set; }
        public string permission_user { get; set; }
    }
}
    