using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Models;

namespace CLHBankApp.Repository.Interface
{
    public interface IRoleRepository
    {
         List<Role> GetAll();
        void Delete(Role role);
        void Update(Role role);
        Role GetRole(int id);
        Role Add(Role role);
        Role GetRole(string name);
    }
}