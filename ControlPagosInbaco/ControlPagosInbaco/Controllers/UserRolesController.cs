using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlPagosInbaco.Controllers
{
    [Authorize(Roles = "ManteUserRoles")]
    public class UserRolesController : Controller
    {
        // GET: UserRoles
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult AccesoInvalido()
        {
            return View();
        }
    }
}