namespace ModularMonolithPoC.Infrastructure.Interfaces;

public interface IUserRepository
{
    Task<bool> UserExists(string login, string passwordHash);
}
