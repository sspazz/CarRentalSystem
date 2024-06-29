using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using System.Collections.Generic;

namespace CarRentalSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
        }
    }
}
