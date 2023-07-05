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
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IRoleRepository _roleRepository;
        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository, IAddressRepository addressRepository, IRoleRepository roleRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _roleRepository = roleRepository;
        }
        public BaseResponse Create(CreateAdminRequestModel model)
        {
            if (model == null)
            {
                return new BaseResponse
                {
                    Message = "Model is null",
                    Status = false
                };
            }
            var role = _roleRepository.GetRole("Admin");
            var user = new User
            {
                Email = model.Email,
                PassWord = model.PassWord,
                RoleId = role.Id,
                Role = role,
            };
            var addUser = _userRepository.Add(user);
            var address = new Address
            {
                City = model.City,
                State = model.State,
                Country = model.Country,
                Street = model.Street,
                UserId = addUser.Id,
                User = addUser,
            };
            _addressRepository.Add(address);
            var admin = new Admin
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                // ImageReference = model.ImageReference,
                UserId = addUser.Id,
                User = addUser
            };
            _adminRepository.Add(admin);
            return new BaseResponse
            {
                Message = "Admin Successfully Created",
                Status = true
            };
        }
        public AdminDto GetAdmin(int id)
        {
            var admin = _adminRepository.GetAdmin(id);
            if (admin == null)
            {
                return null;
            }
            return new AdminDto
            {
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = admin.User.Email,
                PassWord = admin.User.PassWord,
                PhoneNumber = admin.PhoneNumber,
                ImageReference = admin.ImageReference,
            };
        }
        public List<AdminDto> GetAll()
        {
            var admins = _adminRepository.GetAll();
            if (admins.Count == 0)
            {
                return null;
            }
            return admins.Select(x => new AdminDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.User.Email,
                PassWord = x.User.PassWord,
                PhoneNumber = x.PhoneNumber,
                ImageReference = x.ImageReference,
            }).ToList();
        }
        public BaseResponse UpdateAdmin(int id, UpdateAdminRequestModel model)
        {
            var admin = _adminRepository.GetAdmin(id);
            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "Update Failed",
                    Status = false,
                };
            }
            admin.FirstName = model.FirstName;
            admin.LastName = model.LastName;
            admin.PhoneNumber = model.PhoneNumber;
            _adminRepository.Update(admin);
            return new BaseResponse
            {
                Message = "Update Successfully",
                Status = true,
            };
        }
        public BaseResponse DeleteAdmin(int id)
        {
            var admin = _adminRepository.GetAdmin(id);
            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "Admin not found",
                    Status = false
                };
            }
            _adminRepository.Delete(admin);
            return new BaseResponse
            {
                Message = "Profile successfully deleted",
                Status = true
            };
        }

       
    }
}