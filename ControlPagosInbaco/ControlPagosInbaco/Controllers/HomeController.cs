using ControlPagosInbaco.Models;
using MyApplication.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPagosInbaco.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<ABCModelos.Articulo> artlist = ListadoArticulos();
            return View(artlist);
        }

        private List<ABCModelos.Articulo> ListadoArticulos()
        {
            IMBContext dalCtx = new IMBContext();
            return dalCtx.Articulos.ToList();
            /*List<ABCModelos.ArticuloViewModel> listadoArticulos = new List<ABCModelos.ArticuloViewModel>();
            DAL.Conexion con = new DAL.Conexion();

            string query = "SELECT * from articulo";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Connection = con.cn;
                con.AbrirConexion();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        listadoArticulos.Add(new ABCModelos.ArticuloViewModel
                        {
                            IdArticulo = Convert.ToInt64(sdr["idArticulo"])
                        });
                    }
                }
            }
            con.CerrarConexion();

            return listadoArticulos;*/
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}