using ProjectsApi.Application.DTOs;
using ProjectsApi.Domain.Entities;

namespace ProjectsApi.Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<bool> CreateProjectAsync(ProjectDto projectDto);
        Task<bool> UpdateProjectAsync(Project project);
        Task<bool> DeleteProjectAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}