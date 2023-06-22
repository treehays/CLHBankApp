using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Models;

namespace CLHBankApp.Repository.Interface
{
    public interface IAdminRepository
    {
        List<Admin> GetAll();
        void Delete(Admin admin);
        void Update(Admin admin);
        Admin GetAdmin(int id);
        Admin Add(Admin admin);

    }
}