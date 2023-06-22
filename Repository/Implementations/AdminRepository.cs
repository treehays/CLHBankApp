using CLHBankApp.Models;
using CLHBankApp.Models.CLHBankAppContext;
using CLHBankApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CLHBankApp.Repository.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly CLHBankAppContext _cLHBankAppContext;

        public AdminRepository(CLHBankAppContext cLHBankAppContext)
        {
            _cLHBankAppContext = cLHBankAppContext;
        }

        public Admin Add(Admin admin)
        {
            _cLHBankAppContext.Admins.Add(admin);
            _cLHBankAppContext.SaveChanges();
            return admin;
        }

        public void Delete(Admin admin)
        {
            _cLHBankAppContext.Admins.Remove(admin);
            _cLHBankAppContext.SaveChanges();
        }

        public Admin GetAdmin(int id)
        {
           var admin = _cLHBankAppContext.Admins
           .SingleOrDefault(admin => admin.Id == id);
           return admin;
        }

        public List<Admin> GetAll()
        {
            return _cLHBankAppContext.Admins.ToList();
        }

        public void Update(Admin admin)
        {
             _cLHBankAppContext.SaveChanges();
        }
    }
}