using Dapper;
using Microsoft.Extensions.Configuration;
using SamplePOC.Domain.Aggregates;
using SamplePOC.Domain.Entities;
using SamplePOC.Domain.Interfaces;
using System.Data.SqlClient;

namespace SamplePOC.Infrastructure
{
    public class BillerRepository : IBillerRepository
    {
        private readonly IConfiguration configuration;
        public BillerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddBiller(Biller biller)
        {
            var sql = "Insert into Biller (Name) VALUES (@Name)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, biller);
                return result;
            }
        }

        public async Task<Biller> GetBillerById(int id)
        {
            var sql = "SELECT * FROM Biller WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Biller>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> RemoveBiller(Task<Biller> biller)
        {
            var sql = "DELETE FROM Biller WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = biller });
                return result;
            }
        }

        public async Task<int> UpdateBiller(Biller biller)
        {
            var sql = "UPDATE Biller SET Name = @Name WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, biller);
                return result;
            }
        }
    }
}
