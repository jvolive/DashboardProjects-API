using ProjectsApi.Domain.Entities;
using ProjectsApi.Domain.Interfaces;
using System.Data;
using Dapper;

namespace ProjectsApi.Infrastructure.Repository;

public class TaskEntityRepository : ITaskEntityRepository
{
    private readonly IDbConnection _dbConnection;

    public TaskEntityRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<TaskEntity>> GetAllAsync()
    {
        var sql = @"
            SELECT 
                id_task AS Id, 
                name_task AS Name,
                description_task AS Description ,
                proj_id AS ProjectId,
                user_id AS UserId
            FROM tasks";
        return await _dbConnection.QueryAsync<TaskEntity>(sql);
    }

    public async Task<TaskEntity> GetByNameAsync(string name)
    {
        var sql = @"
            SELECT 
                id_task AS Id, 
                name_task AS Name,
                description_task AS Description ,
                proj_id AS ProjectId,
                user_id AS UserId
            FROM tasks
            WHERE name_task = @Name";
        return await _dbConnection.QuerySingleOrDefaultAsync<TaskEntity>(sql, new { Name = name });
    }

    public async Task AddAsync(TaskEntity entity)
    {
        var sql = @"
                INSERT INTO tasks (name_task, description_task, proj_id)
                VALUES (@Name, @Description, @ProjectId)
                RETURNING id_task";
        entity.Id = await _dbConnection.ExecuteScalarAsync<Guid>(sql, entity);
    }


    public async Task DeleteAsync(string name)
    {
        var sql = @"
            DELETE FROM tasks
            WHERE name_task = @Name";

        var parameters = new DynamicParameters();
        parameters.Add("Name", name);

        await _dbConnection.ExecuteAsync(sql, parameters);
    }
}
