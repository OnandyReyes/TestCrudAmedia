using Microsoft.AspNetCore.Mvc;
using TestCrudAmedia.Data.Interface;
using TestCrudAmedia.Data.Repository;
using TestCrudAmedia.ViewModels;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using TestCrudAmedia.Models;

namespace TestCrudAmedia.Controllers
{
    public class LoginController : Controller
    {

        IUsersRepository usersRepository;
        IRolRepository rolRepository;

        public LoginController(TestCrudContext context)
        {
            //AQUI SE INIALIZA LA INTERFACE DE REPOSITORIO CON LA CLASE QUE UTILIZAREMOS PARA LAS OPERACIONES
            usersRepository = new UsersRepository(context);
            rolRepository = new RolRepository(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModels models)
        {
            var user = usersRepository.Validate(models.user, models.password);

            if (user != null && user.CodUsuario > 0)
            {
                //AQUI SE REALIZAN LAS VALIDACIONES PARA SABER SI EL USUARIO ESTA ACTIVO O TIENE ROL ASINADO
                if (user.SnActivo < 1)
                {
                    ViewBag.Mensaje = "El usuario no se encuentra activo.";
                    return View();
                }

                if (user.CodRol == null || user.CodRol <= 0)
                {
                    ViewBag.Mensaje = "El usuario no cuenta con roles asignados.";
                    return View();
                }

                var rol = rolRepository.GetById(user.CodRol.Value);

                if (rol == null || rol.CodRol <= 0)
                {
                    ViewBag.Mensaje = "El usuario no cuenta con roles asignados.";
                    return View();
                }

                //AQUI SE AGREGAN LAS COOKIE PARA GUARDAR LA SESION
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, $"{user.TxtNombre} {user.TxtPassword}" )
                };

                claims.Add(new Claim(ClaimTypes.Role, rol.TxtDesc));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                if (rol.CodRol == 1)
                {
                    return RedirectToAction("Lista", "Usuarios");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }

            ViewBag.Mensaje = "Usuario o contraseña incorrecta.";
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
