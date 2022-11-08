﻿using Microsoft.AspNetCore.Authorization;
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


    }
}
