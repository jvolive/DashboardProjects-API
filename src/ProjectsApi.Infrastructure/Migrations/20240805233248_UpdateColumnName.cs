using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectsApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InputTasks",
                table: "db_projects",
                newName: "input_tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "input_tasks",
                table: "db_projects",
                newName: "InputTasks");
        }
    }
}
