using System;

namespace BarkAvenueApi.Email
{
    public class CreateEmail
    {
        public Mailrequest CreateWelcomeEmail(string toEmail)
        {
            return new Mailrequest
            {
                ToEmail = toEmail,
                Subject = "Welcome to Our Website",
                Body = "Thank you for registering on our website!"
            };
        }
    }
}
