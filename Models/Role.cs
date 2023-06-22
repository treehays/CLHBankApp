using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLHBankApp.Models
{
    public class Role : BaseClass
    {
        public string RoleName { get; set; }
        public IList<User> Users{ get; set; }
    }
}