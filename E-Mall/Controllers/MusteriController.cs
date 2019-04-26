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

namespace E_Mall.Controllers
{
    public class MusteriController : Controller
    {
        MusteriDatabase database;
        public MusteriController()
        {
            database = new MusteriDatabase();
        }
        public ActionResult Listele()
        {
            List<Musteri> musteris = database.GetAll();
            ViewBag.musteriler = musteris;
            return View();
        }
        public ActionResult Arama( Musteri aranan)
        {
            List<Musteri> musteris = database.Arama(aranan);
            ViewBag.musteriler = musteris;
            return View("Listele");
        }
        public ActionResult Sil(int ID)
        {
            Debug.WriteLine("Kullancı Delete Çalıştı.");
            database.Delete(ID);
            return RedirectToAction("Listele");
        }
    }
}