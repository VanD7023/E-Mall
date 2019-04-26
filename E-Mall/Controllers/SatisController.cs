using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using E_Mall.Database;
using System.Web.Mvc;
using E_Mall.Models;
using System.Web;
using System.Diagnostics;

namespace E_Mall.Controllers
{
    public class SatisController : Controller
    {
        SatisDurumDatabase satisDurum;
        SatisDatabase database;
        public SatisController()
        {
            satisDurum = new SatisDurumDatabase();
            database = new SatisDatabase();
        }
        public ActionResult Emirler()
        {
            List<Satis> satis = database.GetAll();
            ViewBag.satislar = satis;
            ViewBag.SatisDurums = new SelectList(satisDurum.GetAll(), "ID", "Adi"); 
            return View();
        }
        public ActionResult Guncelle(int ID)
        {
            Satis satis = database.GetForID(ID);
            List<Satis> item = new SatisDatabase().GetAll();
            ViewBag.SatisDurums = new SelectList(satisDurum.GetAll(), "ID", "Adi");
            return View("EmirDetay", satis);
        }
        [HttpPost]
        public ActionResult Guncelleme(Satis item)
        {
            Debug.WriteLine("Hello Guncelleme");
            database.Update(item);
            return RedirectToAction("Emirler");
        }
        [HttpPost]
        public ActionResult Arama(SatisArama Aranan)
        {
            Debug.WriteLine("Arama Çalıştı");
            List<Satis> satis = database.Arama(Aranan);
            ViewBag.satislar = satis;
            ViewBag.SatisDurums = new SelectList(satisDurum.GetAll(), "ID", "Adi");
            return View("Emirler");
        }
    }
}