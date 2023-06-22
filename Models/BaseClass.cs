using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLHBankApp.Models
{
    public abstract class BaseClass
    {
        public int  Id {get;set;}
        public DateTime DateCreated {get;set;}=  DateTime.Now;

    }
}