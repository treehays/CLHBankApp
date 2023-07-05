using System.Security.Claims;
using CLHBankApp.Dto;
using CLHBankApp.Service.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CLHBankApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]

        public IActionResult LogIn(LogInUserRequestModel model)
        {
            var user = _userService.LogIn(model);
            if (user != null)
            {
                var claims = new List<Claim>
               {
                   new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
                   new Claim (ClaimTypes.Role, user.RoleName),
                   new Claim (ClaimTypes.Email, user.Email),
               };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid Email or Pin";
                return View();
            }
        }

        public IActionResult LogOut()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}