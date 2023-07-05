using CLHBankApp.Dto;
using CLHBankApp.Models;
using CLHBankApp.Repository.Interface;
using CLHBankApp.Service.Interface;

namespace CLHBankApp.Service.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CustomerService(ICustomerRepository customerRepository, IUserRepository userRepository, IRoleRepository roleRepository, IWebHostEnvironment hostEnvironment, IAccountRepository accountRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _hostEnvironment = hostEnvironment;
            _accountRepository = accountRepository;
        }
        public static string GenerateAccountNumber()
        {
            var start = new Random().Next(10000, 99999).ToString();
            var end = new Random().Next(10000, 99999).ToString();
            return $"{start}{end}";
        }
        public BaseResponse Create(CreateCustomerRequestModel model)
        {
            if (model == null)
            {
                return new BaseResponse
                {
                    Message = "Model is null",
                    Status = false
                };
            }
            var customerWithEmail = _userRepository.GetUser(model.Email);
            if (customerWithEmail != null)
            {
                return new BaseResponse
                {
                    Message = "Email Already in Use",
                    Status = false
                };
            }
            if (model.FormFile is null || model.FormFile.Length <= 0)
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "Please select a profile picture"
                };
            }

            var acceptableExtension = new List<string>() { ".jpg", ".jpeg", ".png", ".dnb" };
            var fileExtension = Path.GetExtension(model.FormFile.FileName);
            if (!acceptableExtension.Contains(fileExtension))
            {
                return new BaseResponse()
                {
                    Status = false,
                    Message = "File format not suppported, please upload a picture"
                };
            }
            var role = _roleRepository.GetRole("customer");
            var user = new User
            {
                Email = model.Email,
                PassWord = model.PassWord,
                RoleId = role.Id,
                Role = role,
            };

            var address = new Address
            {
                City = model.City,
                State = model.State,
                Country = model.Country,
                Street = model.Street,
                UserId = user.Id,
            };
            var customer = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                ImageReference = ManageUploadOfProfilePictures(model.FormFile),
                UserId = user.Id,
            };
            user.Address = address;
            user.Customer = customer;
            var addUser = _userRepository.Add(user);
            var account = new Account
            {
                AccountNumber = GenerateAccountNumber(),
                Balance = 0,
                CustomerId = addUser.Customer.Id,
                DateCreated = DateTime.UtcNow,
                Pin = model.Pin
            };


            _accountRepository.Add(account);
            return new BaseResponse
            {
                Message = "Customer Successfully Created",
                Status = true
            };
        }
        public CustomerDTO GetCustomer(int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            if (customer == null)
            {
                return null;
            }
            return new CustomerDTO
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.User.Email,
                PassWord = customer.User.PassWord,
                PhoneNumber = customer.PhoneNumber,
                ImageReference = customer.ImageReference,
            };
        }
        public List<CustomerDTO> GetAll()
        {
            var customers = _customerRepository.GetAll();
            if (customers.Count == 0)
            {
                return null;
            }
            return customers.Select(x => new CustomerDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.User.Email,
                PassWord = x.User.PassWord,
                PhoneNumber = x.PhoneNumber,
                ImageReference = x.ImageReference,
            }).ToList();
        }
        public BaseResponse UpdateCustomer(int id, UpdateCustomerRequestModel model)
        {
            var customer = _customerRepository.GetCustomer(id);
            if (customer == null)
            {
                return new BaseResponse
                {
                    Message = "Update Failed",
                    Status = false,
                };
            }
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.PhoneNumber = model.PhoneNumber;
            _customerRepository.Update(customer);
            return new BaseResponse
            {
                Message = "Update Successfully",
                Status = true,
            };
        }
        public BaseResponse DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            if (customer == null)
            {
                return new BaseResponse
                {
                    Message = "Customer not found",
                    Status = false
                };
            }
            _customerRepository.Delete(customer);
            return new BaseResponse
            {
                Message = "Profile successfully deleted",
                Status = true
            };
        }
        private string ManageUploadOfProfilePictures(IFormFile picture)
        {
            var uploadsFolderPath = Path.Combine(_hostEnvironment.WebRootPath, "ProfilePictures");
            Directory.CreateDirectory(uploadsFolderPath);
            string fileName = Guid.NewGuid() + picture.FileName;
            string photoPath = Path.Combine(uploadsFolderPath, fileName);

            using (var fileStream = new FileStream(photoPath, FileMode.Create))
            {
                picture.CopyTo(fileStream);
            }

            return fileName;
        }
    }
}