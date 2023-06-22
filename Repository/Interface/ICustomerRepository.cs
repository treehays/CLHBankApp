using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Models;

namespace CLHBankApp.Repository.Interface
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        void Delete(Customer customer);
        void Update(Customer customer);
        Customer GetCustomer(int id);
        Customer Add(Customer customer);
    }
}