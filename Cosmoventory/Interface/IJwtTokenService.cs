namespace Cosmoventory.Interface
{
    public interface IJwtTokenService
    {
        public string GenerateToken(int userId, string username, string role);

    }
}
