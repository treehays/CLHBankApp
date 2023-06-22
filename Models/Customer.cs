using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLHBankApp.Models
{
    public class Customer : BaseUser
    {
        public IList<Account> Accounts = new List<Account>();
        public int UserId { get; set; }
        public User User{ get; set; }
        
    }
}