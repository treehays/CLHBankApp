using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLHBankApp.Dto;

namespace CLHBankApp.Service.Interface
{
    public interface IAccountService
    {
        BaseResponse Create(CreateAccountRequestModel model);
        BaseResponse Delete(int id);
        List<AccountDto> GetAll();
        AccountDto Get(int id);
    }
}