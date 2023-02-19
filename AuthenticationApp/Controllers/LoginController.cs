using AuthenticationApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthenticationApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(string returnUrl)
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignIn(string returnUrl)
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim("Edhar","Developer")
                };

                var claimIdentity = new ClaimsIdentity(claims, "Cookie");
                var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync("Cookie", claimsPrincipal);
                return Redirect(model.ReturnUrl);
            }
            return View(model);
        }
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("https://localhost:7268/");
        }
    }
}

