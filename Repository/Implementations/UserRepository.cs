using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Models;
using CLHBankApp.Models.CLHBankAppContext;
using CLHBankApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CLHBankApp.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly CLHBankAppContext _cLHBankAppContext;

        public UserRepository(CLHBankAppContext cLHBankAppContext)
        {
            _cLHBankAppContext = cLHBankAppContext;
        }

        public User Add(User user)
        {
            _cLHBankAppContext.Users.Add(user);
            _cLHBankAppContext.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            _cLHBankAppContext.Users.Remove(user);
            _cLHBankAppContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _cLHBankAppContext.Users.ToList();
        }
        public User GetUser(int id)
        {
            return _cLHBankAppContext.Users.SingleOrDefault(x => x.Id == id);
        }
        public User GetUser(string email)
        {
            return _cLHBankAppContext.Users.SingleOrDefault(x => x.Email == email);
        }
        public User GetUserForLogIn( string email, string password)
        {
            return _cLHBankAppContext.Users
            .Include(x => x.Role)
            .SingleOrDefault( x=> x.Email == email && x.PassWord == password);
        }

        public void Update(User user)
        {
            _cLHBankAppContext.SaveChanges();
        }
    }
}