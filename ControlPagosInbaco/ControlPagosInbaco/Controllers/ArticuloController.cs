using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ControlPagosInbaco.Models;
using System.Collections.Generic;
using MyApplication.DAL;

namespace ControlPagosInbaco.Controllers
{
    [Authorize(Roles = "MantArticulo")]
    public class ArticuloController : Controller
    {
        public static int maxNumberDefault = 100;
        
        /// <summary>
        /// Listado de Artículos
        /// </summary>
        /// <returns></returns>
        
        public ActionResult Index()
        {
            List<Articulo> artlist = ListadoArticulos();
            //return Json(artlist, JsonRequestBehavior.AllowGet); //sample for JSON
            return View(artlist);  //Sample for action result like a View and send the artList as parameters
        }

        /// <summary>
        /// Crea un artículo
        /// </summary>
        /// <param name="articulo"></param>
        public static void crear(Articulo articulo)
        {
            if (articulo == null)
            {
                throw new Exception("No se puede actualizar un artículo que no se ha especificado");
            }

            Articulo tmpArticulo = BuscarArticuloxId(articulo.IdArticulo);

            if (tmpArticulo != null)
            {
                throw new Exception(String.Format("No se puede crear un artículo, porque ya existe el Id {0}", articulo.IdArticulo));
            }

            //save modified entity using new Context
            using (var dbCtx = new IMBContext())
            {
                //Mark entity as modified
                dbCtx.Articulos.Add(articulo);
                //call SaveChanges
                dbCtx.SaveChanges();
            }
        }

        /// <summary>
        /// Obtiene un artículo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public ActionResult obtener(long id)
        {
            return View(BuscarArticuloxId(id));
            //return Json(BuscarArticuloxId(id), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Elimina un artículo
        /// </summary>
        /// <param name="articulo"></param>
        public static void eliminar(Articulo articulo)
        {
            if (articulo == null)
            {
                throw new Exception("No se puede eliminar un artículo que no se ha especificado");
            }

            Articulo tmpArticulo = BuscarArticuloxId(articulo.IdArticulo);

            if (tmpArticulo == null)
            {
                throw new Exception(String.Format("No se encontró el artículo con Id {0}", articulo.IdArticulo));
            }

            //save modified entity using new Context
            using (var dbCtx = new IMBContext())
            {
                //Mark entity as modified
                dbCtx.Articulos.Remove(tmpArticulo);
                //call SaveChanges
                dbCtx.SaveChanges();
            }
        }

        /// <summary>
        /// Actualiza un artículo dado.
        /// </summary>
        /// <param name="articulo"></param>
        public static void actualizar(Articulo articulo)
        {
            if (articulo == null)
            {
                throw new Exception("No se puede actualizar un artículo que no se ha especificado");
            }

            Articulo tmpArticulo = BuscarArticuloxId(articulo.IdArticulo);

            if (tmpArticulo == null)
            {
                throw new Exception(String.Format("No se encontró el artículo con Id {0}",articulo.IdArticulo));
            }

            //save modified entity using new Context
            using (var dbCtx = new IMBContext())
            {
                //Mark entity as modified
                dbCtx.Entry(tmpArticulo).State = System.Data.Entity.EntityState.Modified;
                //call SaveChanges
                dbCtx.SaveChanges();
            }
        }

        /// <summary>
        /// Listado de todos los artículos, filtra por el parámetro maxNumberDefault
        /// </summary>
        /// <returns></returns>
        public static List<Articulo> ListadoArticulos()
        {
            using (var dalCtx = new IMBContext())
            {
                return dalCtx.Articulos.Take(maxNumberDefault).ToList();
            }
        }

        /// <summary>
        /// Búsqueda de un artículo, dado un Id
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public static Articulo BuscarArticuloxId(long _id)
        {
            using (var dalCtx = new IMBContext())
            {
                return dalCtx.Articulos.Where(p => p.IdArticulo == _id).FirstOrDefault<Articulo>();
            }
        }
    }
}