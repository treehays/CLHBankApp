using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Models;
using CLHBankApp.Models.CLHBankAppContext;
using CLHBankApp.Repository.Interface;

namespace CLHBankApp.Repository.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CLHBankAppContext _cLHBankAppContext;

        public RoleRepository(CLHBankAppContext cLHBankAppContext)
        {
            _cLHBankAppContext = cLHBankAppContext;
        }

        public Role Add(Role role)
        {
            _cLHBankAppContext.Roles.Add(role);
            _cLHBankAppContext.SaveChanges();
            return role;
        }

        public void Delete(Role role)
        {
            _cLHBankAppContext.Roles.Remove(role);
            _cLHBankAppContext.SaveChanges();
        }

        public List<Role> GetAll()
        {
            return _cLHBankAppContext.Roles.ToList();
        }
        public Role GetRole(int id)
        {
            return _cLHBankAppContext.Roles.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Role role)
        {
            _cLHBankAppContext.SaveChanges();
        }
    }
}