using ControlPagosInbaco.Models;
using MyApplication.DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using System.Linq;
using System;
using ControlPagosInbaco.Constants;
using System.Net;
using System.Data.Entity.Infrastructure;

namespace ControlPagosInbaco.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class GradoController : Controller
    {
        private IMBContext dbCtx = new IMBContext();

        /// <summary>
        /// Listado de Grados
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int? selectedEstablecimiento)
        {
            /*var establecimientos = dbCtx.Establecimientos.OrderBy(q => q.Descripcion).ToList();
            ViewBag.SelectedEstablecimiento = new SelectList(establecimientos, 
                "IdEstablecimiento", "Descripcion", selectedEstablecimiento);
            int establecimientoId = selectedEstablecimiento.GetValueOrDefault();

            IQueryable<Grado> grados = dbCtx.Grados
                .Where(c => !selectedEstablecimiento.HasValue || c.IdEstablecimiento == establecimientoId)
                .OrderBy(d => d.IdGrado)
                .Include(d => d.Establecimiento);
            var sql = grados.ToString();
            return View(grados.ToList());*/

            List<Grado> gradoList = dbCtx.Grados.Take(GlobalConstants.maxNumberDefault).ToList();
            //return Json(gradoList, JsonRequestBehavior.AllowGet); //sample for JSON
            return View(gradoList);
        }

        /// <summary>
        /// Obtiene un Grado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado tmpGrado = dbCtx.Grados.Find(id);
            if (tmpGrado == null)
            {
                return HttpNotFound();
                //throw new Exception(String.Format("No se encontró el Grado con Id {0}", id));
            }

            return View(tmpGrado);
        }

        /// <summary>
        /// Vista para creacion de grado
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            PopulateEstablecimientoDropDownList();
            return View();
        }

        /// <summary>
        /// Creacion de Grado
        /// </summary>
        /// <param name="Grado"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Descripcion,estado,IdEstablecimiento")]Grado grado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbCtx.Grados.Add(grado);
                    dbCtx.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "No se pudieron guardar los cambios, reintente");
            }
            PopulateEstablecimientoDropDownList(grado.IdEstablecimiento);
            return View(grado);
        }

        /// <summary>
        /// Editar grado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = dbCtx.Grados.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            PopulateEstablecimientoDropDownList(grado.IdEstablecimiento); 
            return View(grado);
        }

        //Grado/Edit/1
        /// <summary>
        /// Actualiza un grado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var courseToUpdate = dbCtx.Grados.Find(id);
            if (TryUpdateModel(courseToUpdate, "",
               new string[] { "Descripcion", "estado","IdEstablecimiento"}))
            {
                try
                {
                    dbCtx.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "No se pudieron actualizar los cambios");
                }
            }
            PopulateEstablecimientoDropDownList(courseToUpdate.IdEstablecimiento);
            return View(courseToUpdate);
        }

        /// <summary>
        /// Visualizacion de grado (detalle)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = dbCtx.Grados.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // POST: Grado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grado grado = dbCtx.Grados.Find(id);
            dbCtx.Grados.Remove(grado);
            dbCtx.SaveChanges();
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Populate Establecimiento List
        /// </summary>
        /// <param name="selectedDepartment"></param>
        private void PopulateEstablecimientoDropDownList(object PopulateEstablecimientoDropDownList = null)
        {
            var departmentsQuery = from d in dbCtx.Establecimientos
                                   orderby d.Descripcion
                                   select d;
            ViewBag.IdEstablecimiento = new SelectList(departmentsQuery, "IdEstablecimiento", "Descripcion",
                PopulateEstablecimientoDropDownList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbCtx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
