using E_Mall.Database;
using E_Mall.Models;
using System;
using System.Collections.Generic;
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
            return View();
        }

        [HttpPost]
        public ActionResult Olustur(Kategori item, HttpPostedFileBase file)
        {
            if (item.ResimID == -1 || item.ResimID==0)
            {
                string path = string.Format("/app-assets/images/kategori/{0}", (DateTime.Now.Ticks + Path.GetExtension(file.FileName)));
                Resim resim = new ResimDatabase().SaveResim(file, path);
                item.ResimID = resim.ID;
            }
            else
            {
                string path = database.GetResim(item.ResimID).Path;
                FileInfo deleteFile = new FileInfo(path);
                if (deleteFile.Exists)
                    deleteFile.Delete();
                path = string.Format("/app-assets/images/kategori/{0}", (DateTime.Now.Ticks + Path.GetExtension(file.FileName)));
                Resim resim = new ResimDatabase().UpdateResim(file, path, item.ResimID);
                item.ResimID = resim.ID;
            }
            database.Insert(item);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int ID)
        {
            database.Delete(ID);
            return RedirectToAction("Index");
        }

        public ActionResult Guncele(int ID)
        {
            Kategori item = database.GetForID(ID);
            ViewBag.Adi = item.Adi;
            ViewBag.Aciklama = item.Aciklama;
            ViewBag.isNew = false;
            return View("Olustur", item);
        }

        public ActionResult Arama(string aranan)
        {
            return View("Index", string.IsNullOrEmpty(aranan) ? database.GetAll() : database.GetForAdi(aranan));
        }
    }
}