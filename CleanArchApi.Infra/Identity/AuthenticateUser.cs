using CleanArchApi.Domain.Auth;
using Microsoft.AspNetCore.Identity;

namespace CleanArchApi.Infra.Identity;

public class AuthenticateUser : IAuthenticate
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _userSignInManager;
    public AuthenticateUser(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> userSignInManager)
    {
        _userManager = userManager;
        _userSignInManager = userSignInManager;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        var user = await _userSignInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);

        return user.Succeeded;
    }

    public async Task<bool> RegisterUserAsync(string email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
            await _userSignInManager.SignInAsync(user, isPersistent: false);

        return result.Succeeded;
    }
}
