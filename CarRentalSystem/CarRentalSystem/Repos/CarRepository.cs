using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalSystem.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly string _connectionString;

        public CarRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Car> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Car>("SELECT * FROM Cars");
        }

        public Car GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Car>("SELECT * FROM Cars WHERE Id = @Id", new { Id = id });
        }

        public void Add(Car car)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO Cars (Make, Model, Type) VALUES (@Make, @Model, @Type)";
            connection.Execute(sql, car);
        }

        public void Update(Car car)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "UPDATE Cars SET Make = @Make, Model = @Model, Type = @Type WHERE Id = @Id";
            connection.Execute(sql, car);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "DELETE FROM Cars WHERE Id = @Id";
            connection.Execute(sql, new { Id = id });
        }
    }
}
