using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace ProjectsApi.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        // Armazenado como uma string JSON na base de dados
        public string InputTasks { get; set; }

        // Propriedade não mapeada, usada para manipular dados JSON
        [NotMapped]
        public List<string> Tasks
        {
            get => string.IsNullOrEmpty(InputTasks)
                ? new List<string>()
                : JsonSerializer.Deserialize<List<string>>(InputTasks);
            set => InputTasks = JsonSerializer.Serialize(value);
        }
    }
}
