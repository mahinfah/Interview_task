using Interview_task.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Interview_task.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

         // LOGIN PAGE
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            string username = _configuration["UserCredentials:Username"];
            string password = _configuration["UserCredentials:Password"];

            if (model.Username == username &&
                model.Password == password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal);

                return RedirectToAction("Secure", "Home");
            }

            ViewBag.Message = "Invalid Username or Password";
            return View(model);
        }

    
        [HttpGet]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(GoogleResponse))
            };

            properties.SetParameter("prompt", "select_account");

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }


        [HttpGet]
        public IActionResult GoogleResponse()
        {
            return RedirectToAction("Secure", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }

    }
}