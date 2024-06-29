using CarRentalSystem.Models;
using System.Collections.Generic;

namespace CarRentalSystem.Interfaces
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
    }
}
