using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public class CustomerRepository
    {
        private readonly CustomerDAO _dao;

        public CustomerRepository()
        {
            _dao = new CustomerDAO();
        }

        public List<Customer> GetAllCustomers()
        {
            return _dao.GetAllCustomers();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _dao.GetCustomerById(customerId);
        }

        public void AddCustomer(Customer customer)
        {
            _dao.AddCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _dao.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            _dao.DeleteCustomer(customerId);
        }
    }
}
