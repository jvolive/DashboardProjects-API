using ProjectsApi.Domain.Entities;

namespace ProjectsApi.Domain.Interfaces;

public interface IProjectRepository : IRepository<Project>
{
    Task<Project> GetByNameAsync(string name);
}
