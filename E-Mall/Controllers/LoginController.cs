using E_Mall.Database;
using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace E_Mall.Controllers
{
    public class LoginController : Controller
    {
        LoginDatabase database;
        public LoginController()
        {
            database = new LoginDatabase();
        }
        public ActionResult Oturum()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dogrulama(Login user)
        {
            Debug.WriteLine(user.KullaniciAdi + " " + user.Sifre);
            if (database.Kontrol(user) != null)
            {
                Debug.WriteLine("Kullanıcı Bulundu");
                Session.Add("Kullanici", user);
                return RedirectToAction("index", "Home");
            }
            else
            {
                Debug.WriteLine("Kullanıcı Bulunamadı");
                return RedirectToAction("Oturum", "Login");
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Oturum", "Login");
        }
    }
}