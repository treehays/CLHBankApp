using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLHBankApp.Models
{
    public class User : BaseClass
    {
        public string Email {get; set;}
        public string PassWord {get;set;}
        public int RoleId {get; set;}
        public Role Role  {get; set;}
        public Admin Admin {get; set;}
        public Customer Customer {get; set;}
    }
}