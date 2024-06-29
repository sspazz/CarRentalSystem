using CarRentalSystem.Models;
using System.Collections.Generic;

namespace CarRentalSystem.Interfaces
{
    public interface IRentalService
    {
        IEnumerable<Rental> GetAllRentals();
        Rental GetRentalById(int id);
        void RentCar(Rental rental);
        void ReturnCar(int rentalId, int extraDays);
    }
}
