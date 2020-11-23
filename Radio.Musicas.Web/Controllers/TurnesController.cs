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
using Radio.Musicas.Web.ViewModel.Musica;
using Radio.Musicas.Web.ViewModel.Turne;

namespace Radio.Musicas.Web.Controllers
{
    public class TurnesController : Controller

    {
        private IRepositorioGenerico<Turne, long>
            repositorioTurnes = new TurnesRepositorio(new MusicaDbContext());
        private IRepositorioGenerico<Musica, int>
            repositorioMusicas = new MusicasRepositorio(new MusicaDbContext());
            
        // GET: Turnes
        public ActionResult Index()
        {
           // var turnes = db.Turnes.Include(t => t.musica);
            return View(Mapper.Map<List<Turne>,List<TurneIndexViewModel>>(repositorioTurnes.Selecionar()));
        }

        // GET: Turnes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turne turne = repositorioTurnes.SelecionarPorId(id.Value);
            if (turne == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Turne, TurneIndexViewModel>(turne));
        }

        // GET: Turnes/Create
        public ActionResult Create()
        {
            // ViewBag.IdMusica = new SelectList(db.Musicas, "Id", "Titulo");
            List<MusicaIndexViewModel> musicas = Mapper.Map<List<Musica>, List<MusicaIndexViewModel>>(repositorioMusicas.Selecionar());
            SelectList dropdownMusicas = new SelectList(musicas, "Id", "Nome");
            ViewBag.DropdownMusicas = dropdownMusicas;
            return View();
        }

        // POST: Turnes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTurne,NomeTurne,IdMusica")] TurneViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Turne turne = Mapper.Map<TurneViewModel, Turne>(viewModel);
                repositorioTurnes.Inserir(turne);
                return RedirectToAction("Index");
            }

            //ViewBag.IdMusica = new SelectList(db.Musicas, "Id", "Titulo", turne.IdMusica);
            return View(viewModel);
        }

        // GET: Turnes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turne turne = repositorioTurnes.SelecionarPorId(id.Value);
            if (turne == null)
            {
                return HttpNotFound();
            }
            //ViewBag.IdMusica = new SelectList(db.Musicas, "Id", "Titulo", turne.IdMusica);
            List<MusicaIndexViewModel> musicas = Mapper.Map<List<Musica>, List<MusicaIndexViewModel>>(repositorioMusicas.Selecionar());
            SelectList dropdownMusicas = new SelectList(musicas, "Id", "Nome");
            ViewBag.DropdownMusicas = dropdownMusicas;
          
            return View(Mapper.Map<Turne,TurneViewModel>(turne));
        }

        // POST: Turnes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTurne,NomeTurne,IdMusica")] TurneViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Turne turne = Mapper.Map<TurneViewModel, Turne>(viewModel);
                repositorioTurnes.Alterar(turne);
                return RedirectToAction("Index");
            }
           // ViewBag.IdMusica = new SelectList(db.Musicas, "Id", "Titulo", turne.IdMusica);
            return View(viewModel);
        }

        // GET: Turnes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turne turne = repositorioTurnes.SelecionarPorId(id.Value);
            if (turne == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Turne,TurneIndexViewModel>(turne));
        }

        // POST: Turnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorioTurnes.ExcluirPorId(id);
            return RedirectToAction("Index");
        }

        
    }
}
