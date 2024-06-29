using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalSystem.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly string _connectionString;

        public RentalRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Rental> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Rental>("SELECT * FROM Rentals");
        }

        public Rental GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Rental>("SELECT * FROM Rentals WHERE Id = @Id", new { Id = id });
        }

        public void Add(Rental rental)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO Rentals (CarId, CustomerId, RentalDate, RentalDays, ExtraDays, Price) VALUES (@CarId, @CustomerId, @RentalDate, @RentalDays, @ExtraDays, @Price)";
            connection.Execute(sql, rental);
        }

        public void Update(Rental rental)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "UPDATE Rentals SET CarId = @CarId, CustomerId = @CustomerId, RentalDate = @RentalDate, RentalDays = @RentalDays, ExtraDays = @ExtraDays, Price = @Price WHERE Id = @Id";
            connection.Execute(sql, rental);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "DELETE FROM Rentals WHERE Id = @Id";
            connection.Execute(sql, new { Id = id });
        }
    }
}
