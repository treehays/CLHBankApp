using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLHBankApp.Models
{
    public  abstract class BaseUser : BaseClass
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string PhoneNumber {get;set;}
        public string ImageReference {get;set;} 
    }
}