using ModularMonolithPoC.Infrastructure.Interfaces;

namespace ModularMonolithPoC.Infrastructure;

internal class MockUserRepository : IUserRepository
{
    private const string _login = "admin";
    private const string _passwordHash = "AIGzFPZPtqDL3ZeCo0a6dLkrPsyfIUqErNf+987s4H3ADHip+UsjbBlZo64llD1WzQ==";

    public async Task<bool> UserExists(string login, string passwordHash)
    {
        return _login == login && _passwordHash == passwordHash;
    }
}
