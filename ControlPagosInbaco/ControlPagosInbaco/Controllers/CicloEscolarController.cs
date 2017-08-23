using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlPagosInbaco.Models;
using MyApplication.DAL;
using Microsoft.AspNet.Identity;
using ControlPagosInbaco.GlobalUtilities;

namespace ControlPagosInbaco.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Authorize]
    public class CicloEscolarController : Controller
    {
        private IMBContext db = new IMBContext();

        // GET: /CicloEscolar/
        public ActionResult Index()
        {
            return View(db.Ciclos.ToList());
        }

        // GET: /CicloEscolar/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CicloEscolar cicloescolar = db.Ciclos.Find(id);
            if (cicloescolar == null)
            {
                return HttpNotFound();
            }
            return View(cicloescolar);
        }

        // GET: /CicloEscolar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CicloEscolar/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdCiclo,Descripcion,Estado")] CicloEscolar cicloescolar)
        {
            if (ModelState.IsValid)
            {
                cicloescolar.IdUsuario = GlobalFunctions.currentUserId(this);
                db.Ciclos.Add(cicloescolar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cicloescolar);
        }

        // GET: /CicloEscolar/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CicloEscolar cicloescolar = db.Ciclos.Find(id);
            if (cicloescolar == null)
            {
                return HttpNotFound();
            }
            return View(cicloescolar);
        }

        // POST: /CicloEscolar/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdCiclo,Descripcion,Estado")] CicloEscolar cicloescolar)
        {
            if (ModelState.IsValid)
            {
                cicloescolar.IdUsuario = GlobalFunctions.currentUserId(this);
                cicloescolar.FechaModificacion = GlobalFunctions.currentDateTime();
                var entry = db.Entry(cicloescolar).State = EntityState.Modified;
                db.Entry(cicloescolar).Property(x => x.FechaCreacion).IsModified = false; //fecha creacion never should be updated
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cicloescolar);
        }

        // GET: /CicloEscolar/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CicloEscolar cicloescolar = db.Ciclos.Find(id);
            if (cicloescolar == null)
            {
                return HttpNotFound();
            }
            return View(cicloescolar);
        }

        // POST: /CicloEscolar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CicloEscolar cicloescolar = db.Ciclos.Find(id);
            db.Ciclos.Remove(cicloescolar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
