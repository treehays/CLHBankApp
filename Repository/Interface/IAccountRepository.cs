using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Models;

namespace CLHBankApp.Repository.Interface
{
    public interface IAccountRepository
    {
        List<Account> GetAll();
        void Delete(Account account);
        void Update(Account account);
        Account GetAccount(int id);
        Account Add(Account account);

    }
}