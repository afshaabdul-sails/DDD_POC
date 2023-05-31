using Dapper;
using Microsoft.Extensions.Configuration;
using SamplePOC.Domain.Entities;
using SamplePOC.Domain.Interfaces;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace SamplePOC.Infrastructure
{
    public class CustomerRepository :ICustomerRepository
    {
        private readonly IConfiguration configuration;
        public CustomerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            string query = "SELECT * FROM Customers";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Customer>(query);
                return (IEnumerable<Customer>)result;
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var sql = "SELECT * FROM Customer WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Customer>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> AddCustomerAsync(Customer customer)
        {
            
            var sql = "Insert into Customer (Name,Street,City,State,Zip) VALUES (@Name, @Street, @City, @State, @Zip)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, customer);
                return result;
            }
        }

        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            var sql = "UPDATE Customer SET Name = @Name, Street = @Street,City =@City, State = @State, Zip =@Zip WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, customer);
                return result;
            }
        }

        public async Task<int> RemoveCustomerAsync(Task<Customer> customer)
        {
            var sql = "DELETE FROM Customer WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id  = customer });
                return result;
            }
        }
    }
}
