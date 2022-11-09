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
            models.listRoles = rolRepository.GetAll();

            TUser user = new TUser();
            user.TxtUser = models.user;
            user.TxtPassword = models.password;
            user.TxtNombre = models.nombre;
            user.TxtApellido = models.apellido;
            user.NroDoc = models.nro_doc;
            user.CodRol = models.cod_rol;
            user.SnActivo = 1;

            if (usersRepository.ValidateNroDoc(user.NroDoc))
            {
                ViewBag.Mensaje = "Usuario no se pudo crear, Este numero de documento ya esta registrado.";
                return View(models);
            }

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
            models.listRoles = rolRepository.GetAll();

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(UsuariosViewModels models)
        {

            models.listRoles = rolRepository.GetAll();

            TUser userOld = usersRepository.GetById(models.cod_usuario);

            TUser user = new TUser();
            user.CodUsuario = models.cod_usuario;
            user.TxtUser = models.user;
            user.TxtPassword = models.password;
            user.TxtNombre = models.nombre;
            user.TxtApellido = models.apellido;
            user.NroDoc = models.nro_doc;
            user.CodRol = models.cod_rol;
            user.SnActivo = userOld.SnActivo;
            if (user.TxtPassword == null)
            {
                user.TxtPassword = userOld.TxtPassword;
            }

            models.tuser = user;

            if (usersRepository.ValidateNroDocUpdate(user.NroDoc, user.CodUsuario))
            {
                ViewBag.Mensaje = "Usuario no se pudo actualizar, Este numero de documento ya esta registrado.";
                return View(models);
            }

            if (usersRepository.Update(user))
            {
                TempData["Mensaje"] = "El Usuario fue Actualizado Correctamente!";
                return RedirectToAction("Lista", "Usuarios");
            }
            
            ViewBag.Mensaje = "Usuario no se pudo actualizar, verifique e intente de nuevo.";
            return View(models);
        }

        public IActionResult Eliminar(int id)
        {
            UsuariosViewModels models = new UsuariosViewModels();

            models.cod_usuario = id;

            return View(models);
        }

        [HttpPost]
        public IActionResult Eliminar(UsuariosViewModels models)
        {
            bool status = usersRepository.Delete(models.cod_usuario);

            if (status)
            {
                TempData["Mensaje"] = "El Usuario fue Eliminado Correctamente!";
                return RedirectToAction("Lista", "Usuarios");
            }

            ViewBag.Mensaje = "Este Usuario no se puede eliminar.";
            return View(models);
        }
    }
}
