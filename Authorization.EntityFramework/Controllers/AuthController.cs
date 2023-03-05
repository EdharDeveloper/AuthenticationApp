using Authorization.EntityFramework.Data;
using Authorization.EntityFramework.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasswordHasher;
using System.Security.Claims;

using System.Text;

namespace Authorization.EntityFramework.Controllers
{
    public class AuthController : Controller
    {
        private readonly DbBuilderContext _context;
        public AuthController(DbBuilderContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SignIn(string returnUrl)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignInAsync(LoginViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var query = _context.Users.Include(x => x.UserRoles);
            var user = query.Where(x => x.UserName == model.UserName).FirstOrDefault();
            if (user == null)
            {
                ViewBag.UserName = model.UserName + "doesn`t exist";
                return View(model);
            }

            if (PasswordHasherProvider.PasswordsComparer(user.PasswordHash, PasswordHasherProvider.GetHash(model.Password)))
            {
                List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,model.UserName),
                        new Claim(ClaimTypes.Role,"Admin")

                    };
                ClaimsIdentity identity = new ClaimsIdentity(claims, "Cookie");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("Cookie", principal);
                return Redirect(model.ReturnUrl);

            }
            else
            {
                ViewBag.UserName = "Password doesn`t correct";
                return View(model);
            }
        }
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("/Home/Index");
        }


    }
}
