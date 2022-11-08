using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestCrudAmedia.Data.Interface;
using TestCrudAmedia.Data.Repository;
using TestCrudAmedia.Models;
using TestCrudAmedia.ViewModels;

namespace TestCrudAmedia.Controllers
{
    public class PeliculaController : Controller
    {
        IPeliculaRepository peliculaRepository;

        public PeliculaController(TestCrudContext context)
        {
            //AQUI SE INIALIZA LA INTERFACE DE REPOSITORIO CON LA CLASE QUE UTILIZAREMOS PARA LAS OPERACIONES
            peliculaRepository = new PeliculaRepository(context);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Lista()
        {
            PeliculaViewModels models = new PeliculaViewModels();

            models.listPeliculas = peliculaRepository.GetAll();

            return View(models);
        }
    }
}
