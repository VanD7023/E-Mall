using E_Mall.Database;
using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace E_Mall.Controllers
{
    public class KategoriController : Controller
    {
        KategoriDatabase database;
        public KategoriController()
        {
            database = new KategoriDatabase();
        }
        public ActionResult Index()
        {
            return View(database.GetAll());
        }
        public ActionResult Olustur()
        {
            List<Kategori> items = database.GetAll();
            items.Insert(0, new Kategori() { ID = 0, Adi = "Ana Kategori" });
            ViewBag.kategoris = new SelectList(items, "ID", "Adi");
            return View();
        }
        [HttpPost]
        public ActionResult Guncelle(Kategori item, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string path = database.GetResim(item.ResimID).Path;
                FileInfo deleteFile = new FileInfo(path);
                if (deleteFile.Exists)
                    deleteFile.Delete();
                path = string.Format("/app-assets/images/kategori/{0}", (DateTime.Now.Ticks + Path.GetExtension(file.FileName)));
                Resim resim = new ResimDatabase().Update(file, path, item.ResimID);
                item.ResimID = resim.ID;
            }
            database.Update(item);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Olustur(Kategori item, HttpPostedFileBase file)
        {
            string path = string.Format("/app-assets/images/kategori/{0}", (DateTime.Now.Ticks + Path.GetExtension(file.FileName)));
            Resim resim = new ResimDatabase().Insert(file, path);
            item.ResimID = resim.ID;
            database.Insert(item);
            return RedirectToAction("Index");
        }
        public ActionResult Guncele(int ID)
        {
            Kategori item = database.GetForID(ID);
            ViewBag.Adi = item.Adi;
            ViewBag.Aciklama = item.Aciklama;
            ViewBag.isNew = false;
            List<Kategori> items = database.GetAll();
            items.Insert(0, new Kategori() { ID = 0, Adi = "Ana Kategori" });
            ViewBag.kategoris = new SelectList(items, "ID", "Adi");
            return View("Olustur", item);
        }
        public ActionResult Sil(int ID)
        {
            database.Delete(ID);
            return RedirectToAction("Index");
        }
        public ActionResult Arama(string aranan)
        {
            return View("Index", string.IsNullOrEmpty(aranan) ? database.GetAll() : database.GetForAdi(aranan));
        }
    }
}