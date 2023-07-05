using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Dto;
using CLHBankApp.Models;

namespace CLHBankApp.Service.Interface
{
    public interface IRoleService
    {
        BaseResponse CreateRole(CreateRoleRequestModel model);
        List<RoleDto> GetAllRole();
        RoleDto GetRole(int id);
        BaseResponse UpdateRole(int id, UpdateRoleRequestModel model);

    }
}