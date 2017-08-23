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
    [Authorize]
    public class SeccionController : Controller
    {
        private IMBContext db = new IMBContext();

        // GET: /Seccion/
        public ActionResult Index()
        {
            var secciones = db.Secciones.Include(s => s.Grado);
            return View(secciones.ToList());
        }

        // GET: /Seccion/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seccion seccion = db.Secciones.Find(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            return View(seccion);
        }

        // GET: /Seccion/Create
        public ActionResult Create()
        {
            
            ViewBag.IdGrado = new SelectList(db.Grados, "IdGrado", "Descripcion");
            return View();
        }

        // POST: /Seccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdSeccion,Descripcion,Estado,IdGrado")] Seccion seccion)
        {
            if (ModelState.IsValid)
            {
                seccion.IdUsuario = GlobalFunctions.currentUserId(this);
                db.Secciones.Add(seccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGrado = new SelectList(db.Grados, "IdGrado", "Descripcion", seccion.IdGrado);
            return View(seccion);
        }

        // GET: /Seccion/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seccion seccion = db.Secciones.Find(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGrado = new SelectList(db.Grados, "IdGrado", "Descripcion", seccion.IdGrado);
            return View(seccion);
        }

        // POST: /Seccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdSeccion,Descripcion,Estado,IdGrado")] Seccion seccion)
        {
            if (ModelState.IsValid)
            {

                seccion.IdUsuario = GlobalFunctions.currentUserId(this);
                seccion.FechaModificacion = GlobalFunctions.currentDateTime();
                var entry = db.Entry(seccion).State = EntityState.Modified;
                db.Entry(seccion).Property(x => x.FechaCreacion).IsModified = false; //fecha creacion never should be updated
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGrado = new SelectList(db.Grados, "IdGrado", "Descripcion", seccion.IdGrado);
            return View(seccion);
        }

        // GET: /Seccion/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seccion seccion = db.Secciones.Find(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            return View(seccion);
        }

        // POST: /Seccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Seccion seccion = db.Secciones.Find(id);
            db.Secciones.Remove(seccion);
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
