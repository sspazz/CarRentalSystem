using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using System;
using System.Collections.Generic;

namespace CarRentalSystem.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;
        private readonly ICustomerRepository _customerRepository;

        public RentalService(IRentalRepository rentalRepository, ICarRepository carRepository, ICustomerRepository customerRepository)
        {
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
            _customerRepository = customerRepository;
        }

        public IEnumerable<Rental> GetAllRentals()
        {
            return _rentalRepository.GetAll();
        }

        public Rental GetRentalById(int id)
        {
            return _rentalRepository.GetById(id);
        }

        public void RentCar(Rental rental)
        {
            var car = _carRepository.GetById(rental.CarId);
            var customer = _customerRepository.GetById(rental.CustomerId);

            if (car == null || customer == null)
                throw new Exception("Invalid car or customer ID");

            rental.Price = CalculateRentalPrice(car.Type, rental.RentalDays);
            customer.LoyaltyPoints += GetLoyaltyPoints(car.Type);
            _customerRepository.Update(customer);

            _rentalRepository.Add(rental);
        }

        public void ReturnCar(int rentalId, int extraDays)
        {
            var rental = _rentalRepository.GetById(rentalId);

            if (rental == null)
                throw new Exception("Invalid rental ID");

            var car = _carRepository.GetById(rental.CarId);

            if (car == null)
                throw new Exception("Invalid car ID");

            rental.ExtraDays = extraDays;
            rental.Price += CalculateExtraPrice(car.Type, extraDays);
            _rentalRepository.Update(rental);
        }

        public decimal CalculateRentalPrice(CarType type, int days)
        {
            switch (type)
            {
                case CarType.Premium:
                    return 300 * days;
                case CarType.SUV:
                    if (days <= 7) return 150 * days;
                    if (days <= 30) return 7 * 150 + (days - 7) * 150 * 0.8m;
                    return 7 * 150 + 23 * 150 * 0.8m + (days - 30) * 150 * 0.5m;
                case CarType.Small:
                    if (days <= 7) return 50 * days;
                    return 7 * 50 + (days - 7) * 50 * 0.6m;
                default:
                    throw new Exception("Invalid car type");
            }
        }

        public decimal CalculateExtraPrice(CarType type, int extraDays)
        {
            switch (type)
            {
                case CarType.Premium:
                    return extraDays * 300 * 1.2m;
                case CarType.SUV:
                    return extraDays * (150 + 50 * 0.6m);
                case CarType.Small:
                    return extraDays * 50 * 1.3m;
                default:
                    throw new Exception("Invalid car type");
            }
        }

        private int GetLoyaltyPoints(CarType type)
        {
            switch (type)
            {
                case CarType.Premium:
                    return 5;
                case CarType.SUV:
                    return 3;
                case CarType.Small:
                    return 1;
                default:
                    throw new Exception("Invalid car type");
            }
        }
    }
}
