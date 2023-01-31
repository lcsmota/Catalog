namespace CleanArchApi.Domain.Auth;

public interface IAuthenticate
{
    Task<bool> AuthenticateAsync(string email, string password);
    Task<bool> RegisterUserAsync(string email, string password);
}
