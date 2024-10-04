namespace ProjectsApi.Domain.Entities;

public class TaskEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid ProjectId { get; set; }
    public Guid UserId { get; set; }
}
