using Microsoft.AspNetCore.Mvc;
using TestCrudAmedia.Data.Interface;
using TestCrudAmedia.Data.Repository;
using TestCrudAmedia.ViewModels;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace TestCrudAmedia.Controllers
{
    public class LoginController : Controller
    {
        IUsersRepository usersRepository;

        public LoginController()
        {
            usersRepository = new UsersRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModels models)
        {
            var user = usersRepository.Validate(models.user, models.password);

            if (user != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, $"{user.TxtNombre} {user.TxtPassword}" )
                };

                String Rol = "Visitante";

                if (user.CodRolNavigation != null)
                    Rol = user.CodRolNavigation.TxtDesc;

                claims.Add(new Claim(ClaimTypes.Role, Rol));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Denegado()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }
    }
}
