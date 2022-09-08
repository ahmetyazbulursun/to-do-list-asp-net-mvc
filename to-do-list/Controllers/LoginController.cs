using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using to_do_list.Models.Entity;

namespace to_do_list.Controllers
{

    [AllowAnonymous]

    public class LoginController : Controller
    {

        Entities db = new Entities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Admin p)
        {
            var value = db.Tbl_Admin.FirstOrDefault(x => x.USERNAME == p.USERNAME && x.PASSWORD == p.PASSWORD);

            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.USERNAME, false);
                Session["USERNAME"] = value.USERNAME.ToString();
                return RedirectToAction("Index", "Home");
            }

            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }



    }
}