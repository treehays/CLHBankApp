using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Models;

namespace CLHBankApp.Repository.Interface
{
    public interface IUserRepository
    {
        List<User> GetAll();
        void Delete(User user);
        void Update(User user);
        User GetUser(int id);
        User Add(User user);
    }
}