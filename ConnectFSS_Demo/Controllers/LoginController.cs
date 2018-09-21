using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConnectFSS_Demo.Models;

namespace ConnectFSS_Demo.Controllers
{
    public class LoginController : Controller
    {
        private ConnectFSSEntities db = new ConnectFSSEntities();

        // GET: Login
        public ActionResult Index()
        {
            if (Session["userId"] != null) { return RedirectToAction("Index", "Accounts"); }

            return View();
        }

        [HttpPost]
        public ActionResult Index( LoginModel login )
        {
            bool userExists = db.Users.Count(user => user.username == login.Username) > 0;
            if (!userExists && login.Username != null )
            {
                ViewBag.NotValidUser = "Username does not exist.";
                return View("Index");
            }
            var encryptedPassword = (from usr in db.Users where usr.username == login.Username select usr.password).FirstOrDefault();
            var password = Utilties.EncryptionHandler.Decrypt(encryptedPassword);
            if (password == login.Password)
            {
                var user = db.Users.First(u => u.username == login.Username);
                Session["userId"] = user.id;
                Session["userName"] = user.first_name + " " + user.last_name;
                Session["userAdmin"] = user.is_admin;
                return RedirectToAction("Index", "Accounts");
            }
            else if (login.Password != null)
            {
                ViewBag.NotValidPassword = "Incorrect password.";
                return View("Index");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["userId"] = null;
            Session["userName"] = null;
            Session["userAdmin"] = null;

            return RedirectToAction("Index", "Login");
        }
    }
}