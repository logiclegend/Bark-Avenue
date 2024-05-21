using System.ComponentModel.DataAnnotations.Schema;

namespace BarkAvenueApi.Models
{
    public class User
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("password_user")]
        public string PasswordUser { get; set; }

        [Column("role_user")]
        public string RoleUser { get; set; }

        [Column("date_registration")]
        public DateTime DateRegistration { get; set; }

        [Column("last_login")]
        public DateTime LastLogin { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("permission_user")]
        public string PermissionUser { get; set; }
    }
}
