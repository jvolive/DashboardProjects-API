using ProjectsApi.Application.Interfaces;
using ProjectsApi.Domain.Entities;
using ProjectsApi.Infrastructure.Data;
using ProjectsApi.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ProjectsApi.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectDbContext _context;

        public ProjectService(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<bool> CreateProjectAsync(ProjectDto projectDto)
        {
            // Converter DTO para entidade
            var project = new Project
            {
                Name = projectDto.Name,
                Description = projectDto.Description,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate,
                InputTasks = projectDto.Tasks != null ? JsonSerializer.Serialize(projectDto.Tasks) : null
            };

            await _context.Projects.AddAsync(project);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return false;
            }

            _context.Projects.Remove(project);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
