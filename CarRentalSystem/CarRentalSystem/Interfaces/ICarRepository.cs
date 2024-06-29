using CarRentalSystem.Models;
using System.Collections.Generic;

namespace CarRentalSystem.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Car GetById(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(int id);
    }
}
