using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestCrudAmedia.Data.Interface;
using TestCrudAmedia.Data.Repository;
using TestCrudAmedia.Models;
using TestCrudAmedia.ViewModels;

namespace TestCrudAmedia.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class GeneroPeliculaController : Controller
    {
        IGeneroPeliculaRepository generoPeliculaRepository;
        IGeneroRepository generoRepository;
        IPeliculaRepository peliculaRepository;

        public GeneroPeliculaController(TestCrudContext context)
        {
            //AQUI SE INIALIZA LA INTERFACE DE REPOSITORIO CON LA CLASE QUE UTILIZAREMOS PARA LAS OPERACIONES
            generoPeliculaRepository = new GeneroPeliculaRepository(context);
            generoRepository = new GeneroRepository(context);
            peliculaRepository = new PeliculaRepository(context);
        }

        public IActionResult Lista(int id)
        {
            GeneroPeliculaViewModels models = new GeneroPeliculaViewModels();

            models.cod_pelicula = id;
            models.pelicula = peliculaRepository.GetById(id);
            models.listGeneros = generoPeliculaRepository.GetAllByCodePelicula(id);

            return View(models);
        }
        public IActionResult Nuevo(int id)
        {
            GeneroPeliculaViewModels models = new GeneroPeliculaViewModels();

            models.cod_pelicula = id;
            models.pelicula = peliculaRepository.GetById(id);
            models.listGeneros = generoRepository.GetAll();

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(GeneroPeliculaViewModels models)
        {
            models.pelicula = peliculaRepository.GetById(models.cod_pelicula);
            models.listGeneros = generoRepository.GetAll();

            bool checkGeneroPelicula = generoPeliculaRepository.GeneroPeliculaCheck(models.cod_pelicula, models.cod_genero);

            if (checkGeneroPelicula)
            {
                ViewBag.Mensaje = "La pelicula ya tiene asignado este Genero.";
                return View(models);
            }

            bool result = generoPeliculaRepository.Insert(models.cod_pelicula, models.cod_genero);

            if (result)
            {
                TempData["Mensaje"] = "El Genero fue Asignado Correctamente!";
                return RedirectToAction("Lista", "GeneroPelicula", new { id = models.cod_pelicula });
            }

            
            ViewBag.Mensaje = "Genero no se pudo asignar, Revise e Intente de nuevo.";
            return View(models);
        }

    }
}
