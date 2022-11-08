using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestCrudAmedia.Data.Interface;
using TestCrudAmedia.Data.Repository;
using TestCrudAmedia.Models;
using TestCrudAmedia.ViewModels;

namespace TestCrudAmedia.Controllers
{
    public class GeneroController : Controller
    {
        IGeneroRepository generoRepository;

        public GeneroController(TestCrudContext context)
        {
            //AQUI SE INIALIZA LA INTERFACE DE REPOSITORIO CON LA CLASE QUE UTILIZAREMOS PARA LAS OPERACIONES
            generoRepository = new GeneroRepository(context);
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Lista()
        {
            GeneroViewModels models = new GeneroViewModels();

            models.listGeneros = generoRepository.GetAll();

            return View(models);
        }
    }
}
