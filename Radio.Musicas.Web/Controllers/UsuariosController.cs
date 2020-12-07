﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Radio.Musicas.Dados.Entity.Context;
using Radio.Musicas.Web.Identity;
using Radio.Musicas.Web.ViewModel.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Radio.Musicas.Web.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        [AllowAnonymous]
        public ActionResult CriarUsuario()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarUsuario(UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new MusicaIdentityDbContext());
                var userManager = new UserManager<IdentityUser>(userStore);
                var identityUser = new IdentityUser
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email
                };
                IdentityResult resultado = userManager.Create(identityUser, viewModel.Senha);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("erro_identity", resultado.Errors.First());
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new MusicaIdentityDbContext());
                var userManager = new UserManager<IdentityUser>(userStore);
                var usuario = userManager.Find(viewModel.Email, viewModel.Senha);
                if (usuario == null)
                {
                    ModelState.AddModelError("erro_identity", "Usuario e/ou Senha incorretos!");
                    return View(viewModel);
                }
                var autManager = HttpContext.GetOwinContext().Authentication;
                var identity = userManager.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                autManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
                {
                    IsPersistent= false
                }, identity);
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }
        [Authorize]
        public ActionResult Logoff() {
            var autManager = HttpContext.GetOwinContext().Authentication;
            autManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}