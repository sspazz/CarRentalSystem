using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using System.Collections.Generic;

namespace CarRentalSystem.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _carRepository.GetAll();
        }

        public Car GetCarById(int id)
        {
            return _carRepository.GetById(id);
        }

        public void AddCar(Car car)
        {
            _carRepository.Add(car);
        }

        public void UpdateCar(Car car)
        {
            _carRepository.Update(car);
        }

        public void DeleteCar(int id)
        {
            _carRepository.Delete(id);
        }
    }
}
