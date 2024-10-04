using ProjectsApi.Domain.Entities;
using ProjectsApi.Domain.Interfaces;
using System.Data;
using Dapper;

namespace ProjectsApi.Infrastructure.Repository;

public class ProjectRepository : IProjectRepository
{
    private readonly IDbConnection _dbConnection;

    public ProjectRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        var sql = @"
            SELECT 
                id_proj AS Id, 
                name_proj AS Name, 
                started_proj AS Started, 
                ended_proj AS Ended
            FROM projects";
        return (await _dbConnection.QueryAsync<Project>(sql)).ToList();
    }

    public async Task<Project> GetByNameAsync(string name)
    {
        var sql = @"
            SELECT 
                id_proj AS Id, 
                name_proj AS Name, 
                started_proj AS Started, 
                ended_proj AS Ended
            FROM projects
            WHERE name_proj = @Name";
        return await _dbConnection.QuerySingleOrDefaultAsync<Project>(sql, new { Name = name });
    }

    public async Task AddAsync(Project entity)
    {
        var sql = @"
            INSERT INTO projects (name_proj)
            VALUES (@Name) 
            RETURNING id_proj";
        entity.Id = await _dbConnection.ExecuteScalarAsync<Guid>(sql, entity);
    }

    public async Task DeleteAsync(string name)
    {
        var sql = @"
        DELETE FROM projects
        WHERE name_proj = @Name";

        var parameters = new DynamicParameters();
        parameters.Add("Name", name);

        await _dbConnection.ExecuteAsync(sql, parameters);
    }
}