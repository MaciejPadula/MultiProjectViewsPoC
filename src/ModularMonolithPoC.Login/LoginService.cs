using Microsoft.AspNet.Identity;
using ModularMonolithPoC.Infrastructure.Interfaces;

namespace ModularMonolithPoC.Login;

public interface ILoginService
{
    Task<bool> ValidateUser(string login, string password);
}

internal class LoginService : ILoginService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public LoginService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<bool> ValidateUser(string login, string password)
    {
        return await _userRepository.UserExists(login, _passwordHasher.HashPassword(password));
    }
}
