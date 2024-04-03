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
}
    