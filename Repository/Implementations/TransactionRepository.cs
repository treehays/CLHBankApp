using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Models;
using CLHBankApp.Models.CLHBankAppContext;
using CLHBankApp.Repository.Interface;

namespace CLHBankApp.Repository.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
       private readonly CLHBankAppContext _cLHBankAppContext;

        public TransactionRepository(CLHBankAppContext cLHBankAppContext)
        {
            _cLHBankAppContext = cLHBankAppContext;
        }

        public Transaction Add(Transaction transaction)
        {
            _cLHBankAppContext.Transactions.Add(transaction);
            _cLHBankAppContext.SaveChanges();
            return transaction;
        }

        public void Delete(Transaction transaction)
        {
            _cLHBankAppContext.Transactions.Remove(transaction);
            _cLHBankAppContext.SaveChanges();
        }

        public List<Transaction> GetAll()
        {
            return _cLHBankAppContext.Transactions.ToList();
        }
        public Transaction GetTransaction(int id)
        {
            return _cLHBankAppContext.Transactions.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Transaction transaction)
        {
            _cLHBankAppContext.SaveChanges();
        }
    }
}