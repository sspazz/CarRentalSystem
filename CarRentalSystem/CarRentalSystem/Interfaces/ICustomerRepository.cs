using CarRentalSystem.Models;
using System.Collections.Generic;


namespace CarRentalSystem.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}
