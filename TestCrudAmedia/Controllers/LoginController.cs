using Microsoft.AspNetCore.Mvc;

namespace TestCrudAmedia.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
