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
    public class PeliculaController : Controller
    {
        IPeliculaRepository peliculaRepository;

        public PeliculaController(TestCrudContext context)
        {
            //AQUI SE INIALIZA LA INTERFACE DE REPOSITORIO CON LA CLASE QUE UTILIZAREMOS PARA LAS OPERACIONES
            peliculaRepository = new PeliculaRepository(context);
        }

        public IActionResult Lista()
        {
            PeliculaViewModels models = new PeliculaViewModels();

            models.listPeliculas = peliculaRepository.GetAll();

            return View(models);
        }

        public IActionResult Nuevo()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(PeliculaViewModels models)
        {
            TPelicula pelicula = new TPelicula();
            pelicula.TxtDesc = models.descripcion;
            pelicula.CantDisponiblesAlquiler = models.cantidad_disponible_alquiler;
            pelicula.CantDisponiblesVenta = models.cantidad_disponible_venta;
            pelicula.PrecioAlquiler = models.precio_alquiler;
            pelicula.PrecioVenta = models.precio_venta;

            int id = peliculaRepository.Insert(pelicula);

            if (id > 0)
            {
                TempData["Mensaje"] = "La Pelicula fue Creada Correctamente!";
                return RedirectToAction("Lista", "Pelicula");
            }

            ViewBag.Mensaje = "Pelicula no se pudo agregar.";
            return View(models);
        }

        public IActionResult Editar(int id)
        {
            PeliculaViewModels models = new PeliculaViewModels();

            models.pelicula = peliculaRepository.GetById(id);

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(PeliculaViewModels models)
        {
            bool status = peliculaRepository.Update(models.pelicula);

            if (status)
            {
                TempData["Mensaje"] = "La Pelicula fue Actualizada Correctamente!";
                return RedirectToAction("Lista", "Pelicula");
            }

            ViewBag.Mensaje = "Pelicula no se actualizo correctamente.";
            return View(models);
        }

        public IActionResult Eliminar(int id)
        {
            PeliculaViewModels models = new PeliculaViewModels();

            models.cod_pelicula = id;

            return View(models);
        }

        [HttpPost]
        public IActionResult Eliminar(PeliculaViewModels models)
        {
            bool status = peliculaRepository.Delete(models.cod_pelicula);

            if (status)
            {
                TempData["Mensaje"] = "La Pelicula fue Eliminada Correctamente!";
                return RedirectToAction("Lista", "Pelicula");
            }

            ViewBag.Mensaje = "Pelicula no se pudo eliminar.";
            return View(models);
        }
    }
}
