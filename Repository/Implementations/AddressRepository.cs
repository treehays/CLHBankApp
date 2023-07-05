using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Models;
using CLHBankApp.Models.CLHBankAppContext;
using CLHBankApp.Repository.Interface;

namespace CLHBankApp.Repository.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CLHBankAppContext _cLHBankAppContext;
        public AddressRepository(CLHBankAppContext cLHBankAppContext)
        {
            _cLHBankAppContext = cLHBankAppContext;
        }
        public Address Add(Address address)
        {
            _cLHBankAppContext.Add(address);
            _cLHBankAppContext.SaveChanges();
            return address;
        }
        public Address GetAddress(int id)
        {
            return _cLHBankAppContext.Addresses.FirstOrDefault(x => x.Id == id);
        }
        public void Update(Address address)
        {
            // _cLHBankAppContext.Update(address);
            _cLHBankAppContext.SaveChanges();
        }
        public void Delete(Address address)
        {
            _cLHBankAppContext.Remove(address);
            _cLHBankAppContext.SaveChanges();
        }
        public List<Address> GetAll()
        {
            return _cLHBankAppContext.Addresses.ToList();
        }
    }
}