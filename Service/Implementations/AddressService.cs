using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Dto;
using CLHBankApp.Models;
using CLHBankApp.Repository.Interface;
using CLHBankApp.Service.Interface;
namespace CLHBankApp.Service.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
         public AddressDto GetAddress(int id)
        {
            var address = _addressRepository.GetAddress(id);
            if (address == null)
            {
                return null;
            }
            return new AddressDto
            {
                Country = address.Country,
                City = address.City,
                Street = address.Street,
                State = address.State,
            };

        }

         public List<AddressDto> GetAll()
        {
            var addresses = _addressRepository.GetAll();
            if (addresses.Count == 0)
            {
                return null;
            }
            return addresses.Select(x => new AddressDto
            {
                Country = x.Country,
                City = x.City,
                Street = x.Street,
                State = x.State,
            }).ToList();
        }

    }
}