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

namespace ControlPagosInbaco.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Authorize]
    public class PerfilController : Controller
    {
        private IMBContext db = new IMBContext();

        // GET: /Perfil/
        public ActionResult Index()
        {
            return View(db.Perfiles.ToList());
        }

        // GET: /Perfil/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfiles.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // GET: /Perfil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Perfil/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IdPerfil,Descripcion,NombreCompleto,Codigo,Telefono,Direccion,Estado")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                perfil.IdUsuario = currentUserId;
                db.Perfiles.Add(perfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perfil);
        }

        // GET: /Perfil/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfiles.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: /Perfil/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IdPerfil,Descripcion,Usuario,NombreCompleto,Codigo,Telefono,Direccion,Estado")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                perfil.IdUsuario = currentUserId;  
                db.Entry(perfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfil);
        }

        // GET: /Perfil/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfiles.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: /Perfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Perfil perfil = db.Perfiles.Find(id);
            db.Perfiles.Remove(perfil);
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
