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

        [Authorize(Roles = "Administrador")]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(GeneroViewModels models)
        {

            TGenero genero = new TGenero();
            genero.TxtDesc = models.descripcion;

            int id = generoRepository.Insert(genero);

            if (id > 0)
            {
                TempData["Mensaje"] = "El Genero fue Creado Correctamente!";
                return RedirectToAction("Lista", "Genero");
            }

            ViewBag.Mensaje = "Genero no se pudo agregar.";
            return View(models);
        }
    }
}
