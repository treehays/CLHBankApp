using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLHBankApp.Models
{
    public class Transaction : BaseClass
    {
        public int AccountId {get;set;}
        public Account Account {get;set;}
    }
}