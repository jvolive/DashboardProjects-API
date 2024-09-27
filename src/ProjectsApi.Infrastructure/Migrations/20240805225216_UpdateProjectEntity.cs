using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectsApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProjectEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "db_projects",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InputTasks",
                table: "db_projects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "db_projects",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "db_projects");

            migrationBuilder.DropColumn(
                name: "InputTasks",
                table: "db_projects");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "db_projects");
        }
    }
}
