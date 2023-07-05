using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Dto;

namespace CLHBankApp.Service.Interface
{
    public interface ICustomerService
    {
        BaseResponse Create(CreateCustomerRequestModel model);
        BaseResponse DeleteCustomer(int id);
        List<CustomerDTO> GetAll();
        CustomerDTO GetCustomer(int id);
        BaseResponse UpdateCustomer(int id, UpdateCustomerRequestModel model);
    }
}