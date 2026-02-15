namespace Cosmoventory.Interface
{
    public interface IAuthService
    {
        Task<AuthResponseDTO?> LoginAsync(string username, string password, string ipAddress);
        Task<AuthResponseDTO?> RefreshAsync(string refreshToken, string ipAddress);
        Task<bool> LogoutAsync(string refreshToken, string ipAddress);
        Task RevokeAllAsync(int userId, string ipAddress);
    }
}
