using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Models;

namespace CLHBankApp.Repository.Interface
{
    public interface ITransactionRepository
    {
         List<Transaction> GetAll();
        void Delete(Transaction transaction);
        void Update(Transaction transaction);
        Transaction GetTransaction(int id);
        Transaction Add(Transaction transaction);
    }
}