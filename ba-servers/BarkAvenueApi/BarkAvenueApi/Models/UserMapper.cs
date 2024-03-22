namespace BarkAvenueApi.Models
{
    public  static class UserMapper
    {
        public static User MapFromRegistrationDTO(RegistrationDTO registrationDTO)
        {
            return new User
            {
                username = registrationDTO.Username,
                email = registrationDTO.Email,
                phone_number = registrationDTO.Phone_number,
                password_user = registrationDTO.Password_user
            };
        }
    }
}
