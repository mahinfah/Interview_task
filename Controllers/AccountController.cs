using Interview_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Interview_task.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;

        // ONLY ONE constructor
        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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
                // Create claims
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, model.Username)
        };

                // Create identity
                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                // Create principal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);



                // Create authentication cookie
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal);

                // Redirect to secure page
                return RedirectToAction("Secure", "Home");
            }

            ViewBag.Message = "Invalid Username or Password";
            return View(model);
        }

        

    }
}