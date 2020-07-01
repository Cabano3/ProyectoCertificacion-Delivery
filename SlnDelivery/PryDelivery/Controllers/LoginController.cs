using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BEUDelivery.Transactions;
namespace PryDelivery.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            try
            {


                {
                    // var oUser = UsuarioBLL.GetUsuario(User, Pass);
                    var Cli = UsuarioBLL.GetCliente(User, Pass);
                    var Adm = UsuarioBLL.GetAdministrador(User, Pass);

                    if (Cli != null && Adm == null)
                    {
                        Session["User"] = Cli;
                        return RedirectToAction("Cliente", "Home");
                        
                    }
                    else if (Cli == null && Adm != null)
                    {
                        Session["User"] = Adm;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Error = "Usuario o contraseña invalida";
                        return View();
                    }


                }


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }
    }
}