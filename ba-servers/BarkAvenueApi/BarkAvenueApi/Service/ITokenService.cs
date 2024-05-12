namespace BarkAvenueApi.Services
{
    public interface ITokenService
    {
        string GenerateToken(string email);
    }
}
