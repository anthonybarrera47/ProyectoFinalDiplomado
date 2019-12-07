using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using Entidades;
using Enums;
using Extensores;
using Herramientas;

namespace ProyectoFinalDiplomado.Controllers
{
    public class TipoArrozController : Controller
    {
        private Contexto db = new Contexto();
        private RepositorioBase<TipoArroz> repositorioBase = new RepositorioBase<TipoArroz>();

        // GET: TipoArroz
        public ActionResult Index()
        {
            var tiposArroz = db.TiposArroz.Include(t => t.Empresas).Include(t => t.Usuario);
            return View(new List<TipoArroz>());
        }
        public ActionResult Nuevo()
        {
            return RedirectToAction("Create");
        }
        // GET: TipoArroz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoArroz tipoArroz = db.TiposArroz.Find(id);
            if (tipoArroz == null)
            {
                return HttpNotFound();
            }
            return View(tipoArroz);
        }

        // GET: TipoArroz/Create
        public ActionResult Create()
        {
            return View(new TipoArroz());
        }

        // POST: TipoArroz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoArrozId,Descripcion,Kilos,Fecha,UsuarioId,EmpresaId")] TipoArroz tipoArroz)
        {
            TiposMensajes tiposMensajes = TiposMensajes.RegistroNoEncontrado;
            TipoTitulo tipoTitulo = TipoTitulo.OperacionFallida;
            IconType iconType = IconType.error;
            tipoArroz.EmpresaId = 1;
            tipoArroz.UsuarioId = 1;
            bool Paso = false;
            if (ModelState.IsValid)
            {
                if (tipoArroz.TipoArrozId == 0)
                {
                    tipoArroz.Kilos = 0;
                    Paso = repositorioBase.Guardar(tipoArroz);
                }
                if (Paso)
                {
                    tipoTitulo = TipoTitulo.OperacionExitosa;
                    tiposMensajes = TiposMensajes.RegistroGuardado;
                    iconType = IconType.success;
                }
                return RedirectToAction("Index");
            }
            Utils.SweetAlert(this.ViewBag, tipoTitulo, tiposMensajes, iconType);

            return View(tipoArroz);
        }
        private bool ExisteEnLaBaseDeDatos(TipoArroz tipo)
        {
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            TipoArroz tipoArroz = repositorio.Buscar(tipo.TipoArrozId);
            repositorio.Dispose();
            return !tipoArroz.EsNulo();
        }
        // GET: TipoArroz/Edit/5
        public ActionResult Edit(int? id)
        {
            TipoArroz tipo = new TipoArroz();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                tipo = repositorioBase.Buscar(id.ToInt());
            }
            return View(tipo);
        }
        // POST: TipoArroz/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoArrozId,Descripcion,Kilos,Fecha,UsuarioId,EmpresaId")] TipoArroz tipoArroz)
        {
            bool Paso = false;
            TiposMensajes tiposMensajes = TiposMensajes.RegistroNoEncontrado;
            TipoTitulo tipoTitulo = TipoTitulo.OperacionFallida;
            IconType iconType = IconType.error;
            if (ModelState.IsValid)
            {
                if (!ExisteEnLaBaseDeDatos(tipoArroz))
                {
                    Utils.ToastSweet(this.ViewBag, IconType.info, TiposMensajes.RegistroNoEncontrado);
                    return null;
                }
                else
                {
                    tipoArroz.Kilos = repositorioBase.Buscar(tipoArroz.TipoArrozId).Kilos;
                    Paso = repositorioBase.Modificar(tipoArroz);
                }
                if (Paso)
                {
                    tipoTitulo = TipoTitulo.OperacionExitosa;
                    tiposMensajes = TiposMensajes.RegistroGuardado;
                    iconType = IconType.success;
                }
                Utils.SweetAlert(this.ViewBag, tipoTitulo, tiposMensajes, iconType);
                return RedirectToAction("Index");
            }
            Utils.SweetAlert(this.ViewBag, tipoTitulo, tiposMensajes, iconType);
            return View(tipoArroz);
        }

        // GET: TipoArroz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoArroz tipoArroz = db.TiposArroz.Find(id);
            if (tipoArroz == null)
            {
                return HttpNotFound();
            }
            return View(tipoArroz);
        }

        // POST: TipoArroz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoArroz tipoArroz = db.TiposArroz.Find(id);
            db.TiposArroz.Remove(tipoArroz);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
         //'filtroPor': $("#FiltrarPor option:selected").val(), 'criterio': $("#CriterioTextBox").val(), 'filtraPorFecha': $("#FiltrarPorFechaCB").is(":checked") 
        public ActionResult Busqueda(string filtroPor, string Criterio, string filtraPorFecha,string desde,string hasta)
        {
            Expression<Func<TipoArroz, bool>> filtro = x => true;
            List<TipoArroz> lista = new List<TipoArroz>();
            bool.TryParse(filtraPorFecha, out bool result);
            switch (filtroPor.ToInt())
            {
                case 0:
                    filtro = x => true;
                    break;
                case 1:
                    filtro = x => x.Descripcion.Contains(Criterio);
                    break;
            }
            DateTime Desde = desde.ToDatetime();
            DateTime Hasta = hasta.ToDatetime();
            if (result && !string.IsNullOrWhiteSpace(desde) && !string.IsNullOrWhiteSpace(hasta))
                lista = repositorioBase.GetList(filtro).Where(x => x.Fecha >= Desde && x.Fecha <= Hasta).ToList();
            else
                lista = repositorioBase.GetList(filtro);
            lista = repositorioBase.GetList(x => true);
            return PartialView("_TipoArrozSearch", lista);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                repositorioBase.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
