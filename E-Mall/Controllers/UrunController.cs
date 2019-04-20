using E_Mall.Database;
using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
namespace E_Mall.Controllers
{
    public class UrunController : Controller
    {
        UrunDatabase database;
        public UrunController()
        {
            database = new UrunDatabase();
        }
        public ActionResult UrunYonetim()
        {
            ResimDatabase resimdata = new ResimDatabase();
            List<Urun> uruns = database.GetAll();
            foreach(Urun item in uruns){
                Resim resim = resimdata.GetForUrunID(item.ID);
                item.Yol = resim != null ? resim.Path : "/app-assets/images/web/fotoyok.jpg";
                Debug.WriteLine(item.Yol);
            }
            return View(uruns);
        }
        public ActionResult UrunEkle()
        {
            List<Kategori> kategoris = new KategoriDatabase().GetAll();
            ViewBag.kategoris = new SelectList(kategoris, "ID", "Adi");
            return View();
        }
        [HttpPost] 
        public ActionResult Ekle(Urun item,HttpPostedFileBase[] files)
        {
            int ID = database.InsertUrun(item);
            ResimDatabase resimDatabase = new ResimDatabase();
            foreach(var item2 in files)
            {
                string path = string.Format("/app-assets/images/urunler/{0}", (DateTime.Now.Ticks + Path.GetExtension(item2.FileName)));
                resimDatabase.Insert(item2, path,ID);
            }

            return RedirectToAction("UrunYonetim");
        }
        [HttpPost]
        public ActionResult Guncelle(Urun item, HttpPostedFileBase[] files)
        {
            database.Update(item);
            return RedirectToAction("UrunYonetim");
        }

        public ActionResult Sil(int ID)
        {
            database.Delete(ID);
            return RedirectToAction("UrunYonetim");
        }

        public ActionResult Arama(string aranan)
        {
            ResimDatabase resimdata = new ResimDatabase();
            List<Urun> uruns = string.IsNullOrEmpty(aranan) ? database.GetAll() : database.GetForAdi(aranan);
            foreach (Urun item in uruns)
            {
                Resim resim = resimdata.GetForUrunID(item.ID);
                item.Yol = resim != null ? resim.Path : "/app-assets/images/web/fotoyok.jpg";
                Debug.WriteLine(item.Yol);
            }
            return View("UrunYonetim",uruns);
        }

        public ActionResult Guncelle(int ID)
        {
            Urun urun = database.GetForID(ID);
            List<Kategori> kategoris = new KategoriDatabase().GetAll();
            ViewBag.kategoris = new SelectList(kategoris, "ID", "Adi");
            return View("UrunEkle", urun);
        }
        public ActionResult Olustur()
        {
            return View();
        }
    }
}