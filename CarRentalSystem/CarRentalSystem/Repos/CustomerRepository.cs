using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalSystem.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Customer> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Customer>("SELECT * FROM Customers");
        }

        public Customer GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Customer>("SELECT * FROM Customers WHERE Id = @Id", new { Id = id });
        }

        public void Add(Customer customer)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO Customers (Name, LoyaltyPoints) VALUES (@Name, @LoyaltyPoints)";
            connection.Execute(sql, customer);
        }

        public void Update(Customer customer)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "UPDATE Customers SET Name = @Name, LoyaltyPoints = @LoyaltyPoints WHERE Id = @Id";
            connection.Execute(sql, customer);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "DELETE FROM Customers WHERE Id = @Id";
            connection.Execute(sql, new { Id = id });
        }
    }
}
