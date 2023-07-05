using CLHBankApp.Dto;
using CLHBankApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CLHBankApp.Controllers
{
    //[Authorize(Roles =("Admin, Customer"))]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult SignUp(CreateCustomerRequestModel model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var signUp = _customerService.Create(model);
                if (signUp.Status == true)
                {
                    return RedirectToAction("Index");
                }
                return View(signUp);
            }
            return View();
        }
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAll();
            if (customers is null)
            {
                return View(Enumerable.Empty<CustomerDTO>());
            }
            return View(customers);
        }

        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer is null)
            {
                return NotFound();
            }
            return View(customer);
        }

        public IActionResult CustomerUpdate(int id)
        {
            var custo = _customerService.GetCustomer(id);
            return View(custo);
        }

        [HttpPost]
        public IActionResult CustomerUpdate(int id, UpdateCustomerRequestModel model)
        {
            var customer = _customerService.UpdateCustomer(id, model);
            return View();
        }

    }
}