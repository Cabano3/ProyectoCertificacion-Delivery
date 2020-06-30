using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PryDelivery.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult Enter(string user, string password)
        {


            try
            {
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content("Ocuriio un error:(" + ex.Message);

            }

        }
    }
}