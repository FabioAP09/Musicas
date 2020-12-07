using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Radio.Musicas.Dados.Entity.Context;
using Radio.Musicas.Dominio;
using Radio.Musicas.Repositorios.Comum;
using Radio.Musicas.Repositorios.Entity;
using Radio.Musicas.Web.Filtros;
using Radio.Musicas.Web.ViewModel.Musica;

namespace Radio.Musicas.Web.Controllers
{
    [LogActionFilter]
    
    public class MusicasController : Controller
    {
        private IRepositorioGenerico<Musica, int>
            repositoriomusicas = new MusicasRepositorio(new MusicaDbContext());

        // GET: Musicas
        
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Musica>,List<MusicaIndexViewModel>>(repositoriomusicas.Selecionar()));
        }

        public ActionResult FiltrarPorNome(string pesquisa)
        {
            List<Musica> musicas = repositoriomusicas.Selecionar()
            .Where(a => a.Titulo.Contains(pesquisa)).ToList();
            List<MusicaIndexViewModel> viewModels = Mapper.Map<List<Musica>, List<MusicaIndexViewModel>>(musicas);
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        // GET: Musicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositoriomusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica,MusicaViewModel>(musica));
        }

        // GET: Musicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musicas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Artista,Album,Ano,Email")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositoriomusicas.Inserir(musica);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Musicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositoriomusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica, MusicaViewModel>(musica));
        }

        // POST: Musicas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Artista,Album,Ano,Email")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositoriomusicas.Alterar(musica);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Musicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositoriomusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica,MusicaIndexViewModel>(musica));
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositoriomusicas.ExcluirPorId(id);
            return RedirectToAction("Index");
        }

    }
}
