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
using ControlPagosInbaco.Constants;
using Microsoft.AspNet.Identity;
using ControlPagosInbaco.GlobalUtilities;

namespace ControlPagosInbaco.Controllers
{
    [Authorize]
    public class EstablecimientoController : Controller
    {
        private IMBContext db = new IMBContext();

        // GET: Establecimiento
        public ActionResult Index()
        {
            return View(db.Establecimientos.Take(GlobalConstants.maxNumberDefault).ToList());
        }

        // GET: Establecimiento/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establecimiento establecimiento = db.Establecimientos.Find(id);
            if (establecimiento == null)
            {
                return HttpNotFound();
            }
            return View(establecimiento);
        }

        // GET: Establecimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Establecimiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Descripcion,Estado,Nombre,Logo")] Establecimiento establecimiento)
        {
            if (ModelState.IsValid)
            {
                establecimiento.IdUsuario = GlobalFunctions.currentUserId(this);
                establecimiento.FechaCreacion = GlobalFunctions.currentDateTime();
                db.Establecimientos.Add(establecimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(establecimiento);
        }

        // GET: Establecimiento/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establecimiento establecimiento = db.Establecimientos.Find(id);
            if (establecimiento == null)
            {
                return HttpNotFound();
            }
            return View(establecimiento);
        }

        // POST: Establecimiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstablecimiento,Descripcion,Estado,Nombre,Logo")] Establecimiento establecimiento)
        {
            if (ModelState.IsValid)
            {
                establecimiento.IdUsuario = GlobalFunctions.currentUserId(this);
                establecimiento.FechaModificacion = GlobalFunctions.currentDateTime();
                var entry = db.Entry(establecimiento).State = EntityState.Modified;
                db.Entry(establecimiento).Property(x => x.FechaCreacion).IsModified = false; //fecha creacion never should be updated
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(establecimiento);
        }

        // GET: Establecimiento/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establecimiento establecimiento = db.Establecimientos.Find(id);
            if (establecimiento == null)
            {
                return HttpNotFound();
            }
            return View(establecimiento);
        }

        // POST: Establecimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Establecimiento establecimiento = db.Establecimientos.Find(id);
            db.Establecimientos.Remove(establecimiento);
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
