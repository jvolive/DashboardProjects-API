using Microsoft.EntityFrameworkCore;
using ProjectsApi.Domain.Entities;

namespace ProjectsApi.Infrastructure.Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var project = modelBuilder.Entity<Project>();
            project.ToTable("db_projects");
            project.HasKey(x => x.Id);
            project.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            project.Property(x => x.Name).HasColumnName("name").IsRequired();
            project.Property(x => x.Description).HasColumnName("description");
            project.Property(x => x.InputTasks)
                .HasColumnName("input_tasks")
                .HasColumnType("jsonb");
        }
    }
}
