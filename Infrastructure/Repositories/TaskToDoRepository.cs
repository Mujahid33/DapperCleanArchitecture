using Application.Interfaces;
using Core.Entities;
using Dapper;
using System.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class TaskToDoRepository : ITaskToDoRepository
    {
        private readonly IConfiguration configuration;

        public TaskToDoRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(TaskToDo entity)
        {
            string query = $"INSERT INTO dbo.TaskToDo (TaskName, TaskDescription)" +
                $"VALUES(@TaskName, @TaskDescription)";

            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.ExecuteAsync(query, entity);
            return result;
        }

        public async Task<int> DeleteAsync(int id)
        {
            string query = $"DELETE FROM dbo.TaskToDo WHERE Id = @Id";

            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.ExecuteAsync(query, new {Id = id});
            return result;
        }

        public async Task<IReadOnlyList<TaskToDo>> GetAllAsync()
        {
            string query = "SELECT * FROM dbo.TaskToDo";

            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.QueryAsync<TaskToDo>(query);
            return result.ToList();
        }

        public async Task<TaskToDo> GetByIdAsync(int Id)
        {
            string query = "SELECT * FROM dbo.TaskToDo WHERE Id=@Id";

            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.QueryFirstOrDefaultAsync<TaskToDo>(query, new {Id = Id});

            return result;
        }

        public async Task<int> UpdateAsync(TaskToDo entity)
        {
            string query = "UPDATE dbo.TaskToDo SET TaskName = @TaskName, TaskDescription = @TaskDescription WHERE Id = @Id";

            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.ExecuteAsync(query, entity);
            return result;
        }
    }
}
