using CLHBankApp.Models;

namespace CLHBankApp.Repository.Interface
{
    public interface IAddressRepository
    {
        List<Address> GetAll();
        void Delete(Address Address);
        void Update(Address Address);
        Address GetAddress(int id);
        Address Add(Address Address);

    }
}