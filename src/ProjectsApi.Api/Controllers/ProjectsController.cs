using Microsoft.AspNetCore.Mvc;
using ProjectsApi.Application.Interfaces;
using ProjectsApi.Application.DTOs;
using ProjectsApi.Domain.Entities;

namespace ProjectsApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _projectService.GetProjectsAsync();
            return projects.Any()
                ? Ok(projects)
                : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            return project != null
                ? Ok(project)
                : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProjectDto projectDto)
        {
            try
            {
                // Criar o projeto usando o DTO
                await _projectService.CreateProjectAsync(projectDto);

                if (await _projectService.SaveChangesAsync())
                {
                    return Ok("Project added successfully");
                }
                return BadRequest("Error adding project");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Project project)
        {
            if (id != project.Id) return BadRequest("Project ID mismatch");

            var result = await _projectService.UpdateProjectAsync(project);
            return result
                ? Ok("Project updated successfully")
                : NotFound("Project not found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _projectService.DeleteProjectAsync(id);
            return result
                ? Ok("Project deleted successfully")
                : NotFound("Project not found");
        }
    }
}
