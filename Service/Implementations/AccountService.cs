using CLHBankApp.Dto;
using CLHBankApp.Repository.Interface;
using CLHBankApp.Service.Interface;

namespace CLHBankApp.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public BaseResponse Create(CreateAccountRequestModel model)
        {

            throw new NotImplementedException();
        }

        public BaseResponse Delete(int id)
        {
            var account = _accountRepository.GetAccount(id);
            if (account == null)
            {
                return new BaseResponse
                {
                    Message = "Account not found",
                    Status = false
                };
            }
            _accountRepository.Delete(account);
            return new BaseResponse
            {
                Message = "Account successfully deleted",
                Status = true
            };
        }

        public AccountDto Get(int id)
        {
            var account = _accountRepository.GetAccount(id);
            if (account == null)
            {
                return null;
            }
            return new AccountDto
            {

            };
        }

        public List<AccountDto> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}