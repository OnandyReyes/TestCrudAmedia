using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestCrudAmedia.Controllers
{
    
    public class HomeController : Controller
    {
        [Authorize(Roles = "Administrador, Visitante")]
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
