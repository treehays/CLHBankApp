using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Dto;

namespace CLHBankApp.Service.Interface
{
    public interface IAdminService
    {
        BaseResponse Create(CreateAdminRequestModel model);
        BaseResponse DeleteAdmin(int id);
        List<AdminDto> GetAll();
        AdminDto GetAdmin(int id);
        BaseResponse UpdateAdmin(int id, UpdateAdminRequestModel model);
    }
}