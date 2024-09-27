using System.ComponentModel.DataAnnotations;

namespace ProjectsApi.Application.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<string> Tasks { get; set; }
    }
}