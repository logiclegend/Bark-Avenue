namespace BarkAvenueApi.Models
{
    public static class UserMapper
    {
        public static User MapFromRegistrationDTO(RegistrationDTO registrationDTO)
        {
            return new User
            {
                Username = registrationDTO.Username,
                Email = registrationDTO.Email,
                PhoneNumber = registrationDTO.Phone_number,
                PasswordUser = registrationDTO.Password_user
            };
        }
    }
}
