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
    public class UsuariosController : Controller
    {
        IUsersRepository usersRepository;
        IRolRepository rolRepository;

        public UsuariosController(TestCrudContext context)
        {
            //AQUI SE INIALIZA LA INTERFACE DE REPOSITORIO CON LA CLASE QUE UTILIZAREMOS PARA LAS OPERACIONES
            usersRepository = new UsersRepository(context);
            rolRepository = new RolRepository(context);
        }

        
        public async Task<IActionResult> Lista()
        {
            UsuariosViewModels models = new UsuariosViewModels();

            models.listUsers = usersRepository.GetAll();
            models.listRoles = rolRepository.GetAll();

            return View(models);
        }

        public async Task<IActionResult> Nuevo()
        {
            UsuariosViewModels models = new UsuariosViewModels();

            models.listRoles = rolRepository.GetAll();

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(UsuariosViewModels models)
        {
            TUser user = new TUser();
            user.TxtUser = models.user;
            user.TxtPassword = models.password;
            user.TxtNombre = models.nombre;
            user.TxtApellido = models.apellido;
            user.NroDoc = models.nro_doc;
            user.CodRol = models.cod_rol;
            user.SnActivo = 1;

            int id = usersRepository.Insert(user);

            if (id > 0)
            {
                TempData["Mensaje"] = "El Usuario fue Creado Correctamente!";
                return RedirectToAction("Lista", "Usuarios");
            }

            ViewBag.Mensaje = "Usuario no se pudo agregar.";
            return View(models);
        }

        public async Task<IActionResult> Editar(int id)
        {
            UsuariosViewModels models = new UsuariosViewModels();

            models.tuser = usersRepository.GetById(id);

            return View(models);
        }
    }
}
