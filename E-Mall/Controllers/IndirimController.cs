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
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace E_Mall.Controllers
{
    public class IndirimController : Controller
    {
        IndirimDatabase database;

        public IndirimController()
        {
            database = new IndirimDatabase();
        }
        public ActionResult Indirimler()
        {
            List<Indirim> indirims = database.GetAll();
            ViewBag.indirimler = indirims;
            return View();
        }
        public ActionResult Ekle(Indirim item)
        {
            //database.Insert(item);
            return View();
        }
        public ActionResult Guncelle(int ID)
        {
            Indirim item = database.GetForID(ID);
            return View("Ekle",item);
        }

        public ActionResult Arama(Indirim aranan)
        {
            List<Indirim> indirims = database.Arama(aranan);
            ViewBag.indirimler = indirims;
            return View("Indirimler");
        }

        [HttpPost] 
        public ActionResult Olustur(Indirim item)
        {
            Debug.WriteLine("Indirim Ekle Calisti");
            database.Insert(item);
            return RedirectToAction("Indirimler");
        }

        [HttpPost]
        public ActionResult Guncelleme(Indirim item)
        {
            Debug.WriteLine("Indirim Guncelle Calisti");
            database.Update(item);
            return RedirectToAction("Indirimler");
        }
        public ActionResult Sil(int ID)
        {
            database.Delete(ID);
            return RedirectToAction("Indirimler");
        }
    }
}