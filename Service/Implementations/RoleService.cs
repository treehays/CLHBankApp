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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public BaseResponse CreateRole(CreateRoleRequestModel model)
        {
            if (model == null)
            {
                return new BaseResponse
                {
                    Message = "Model is null",
                    Status = false
                };
            }
            var role = new Role
            {
                RoleName = model.RoleName,
            };
            _roleRepository.Add(role);
            return new BaseResponse
            {
                Message = "Role created successfully",
                Status = true
            };
        }

        public RoleDto GetRole(int id)
        {
            var role = _roleRepository.GetRole(id);
            if (role == null)
            {
                return null;
            }
            return new RoleDto
            {
                RoleName = role.RoleName,
            };
        }

        public List<RoleDto> GetAllRole()
        {
            var allRole = _roleRepository.GetAll();
            return allRole.Select(x => new RoleDto
            {
                RoleName = x.RoleName,
            }).ToList();
        }

        public BaseResponse UpdateRole(int id, UpdateRoleRequestModel model)
        {
            var newrole = _roleRepository.GetRole(id);
            if (newrole == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Role does not exist",
                };
            }
            newrole.RoleName = model.RoleName;
            _roleRepository.Update(newrole);
            return new BaseResponse
            {
                Message = "Update Successfully",
                Status = true,
            };

        }
    }
}