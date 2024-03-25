namespace BarkAvenueApi.Models
{
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
