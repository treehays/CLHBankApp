using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Dto;

namespace CLHBankApp.Service.Interface
{
 public interface IAddressService
    {
        AddressDto GetAddress(int id);
        List<AddressDto> GetAll();
    }
}