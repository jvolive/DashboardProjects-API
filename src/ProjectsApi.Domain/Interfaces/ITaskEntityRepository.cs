using ProjectsApi.Domain.Entities;

namespace ProjectsApi.Domain.Interfaces;

public interface ITaskEntityRepository : IRepository<TaskEntity>
{
    Task<TaskEntity> GetByNameAsync(string name);
}
