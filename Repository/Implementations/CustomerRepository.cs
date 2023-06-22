using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Models;
using CLHBankApp.Models.CLHBankAppContext;
using CLHBankApp.Repository.Interface;

namespace CLHBankApp.Repository.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CLHBankAppContext _cLHBankAppContext;

        public CustomerRepository(CLHBankAppContext cLHBankAppContext)
        {
            _cLHBankAppContext = cLHBankAppContext;
        }

        public Customer Add(Customer customer)
        {
            _cLHBankAppContext.Customers.Add(customer);
            _cLHBankAppContext.SaveChanges();
            return customer;
        }

        public void Delete(Customer customer)
        {
            _cLHBankAppContext.Customers.Remove(customer);
            _cLHBankAppContext.SaveChanges();
        }

        public List<Customer> GetAll()
        {
            return _cLHBankAppContext.Customers.ToList();
        }
        public Customer GetCustomer(int id)
        {
            return _cLHBankAppContext.Customers.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Customer customer)
        {
            _cLHBankAppContext.SaveChanges();
        }
    }
}