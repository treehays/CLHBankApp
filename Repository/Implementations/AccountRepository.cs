using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Models;
using CLHBankApp.Models.CLHBankAppContext;
using CLHBankApp.Repository.Interface;

namespace CLHBankApp.Repository.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CLHBankAppContext _cLHBankAppContext;
        public AccountRepository(CLHBankAppContext cLHBankAppContext)
        {
            _cLHBankAppContext = cLHBankAppContext;
        }
        public Account Add(Account account)
        {
            _cLHBankAppContext.Add(account);
            _cLHBankAppContext.SaveChanges();
            return account;
        }
        public Account GetAccount(int id)
        {
            return _cLHBankAppContext.Accounts.FirstOrDefault(x => x.Id == id);
        }
        public void Update(Account account)
        {
            // _cLHBankAppContext.Update(account);
            _cLHBankAppContext.SaveChanges();
        }
        public void Delete(Account account)
        {
            _cLHBankAppContext.Remove(account);
            _cLHBankAppContext.SaveChanges();
        }
        public List<Account> GetAll()
        {
            return _cLHBankAppContext.Accounts.ToList();
        }
    }
}