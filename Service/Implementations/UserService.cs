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
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto LogIn (LogInUserRequestModel model)
        {
            var logIn = _userRepository.GetUserForLogIn(model.Email, model.PassWord);
            if(logIn == null)
            {
                return null;

            }
            return new UserDto
            {
                Id = logIn.Id,
                Email = logIn.Email,
                RoleName = logIn.Role.RoleName,
            };

        }
    }
}