using ProjectsApi.Domain.Entities;

namespace ProjectsApi.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetByUsernameAsync(string username);
    Task<bool> VerifyUserPasswordAsync(string username, string password);
    Task<User> GetByNameAsync(string name);
}
