using CarRentalSystem.Models;
using System.Collections.Generic;

namespace CarRentalSystem.Interfaces
{
    public interface IRentalRepository
    {
        IEnumerable<Rental> GetAll();
        Rental GetById(int id);
        void Add(Rental rental);
        void Update(Rental rental);
        void Delete(int id);
    }
}
