using E_Mall.Database;
using E_Mall.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

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
            return View(database.GetAll());
        }
        public ActionResult UrunEkle()
        {
            return View();
        }
        public ActionResult ResimEkle()
        {
            return View();
        }
        public ActionResult Olustur(Urun item)
        {
            database.Insert(item);
            return View("UrunYonetim");
        }
        public ActionResult Sil(int ID)
        {
            database.Delete(ID);
            return RedirectToAction("UrunYonetim");
        }
        public ActionResult Arama(string aranan)
        {
            return View("UrunYonetim", string.IsNullOrEmpty(aranan) ? database.GetAll() : database.GetForAdi(aranan));
        }
        public ActionResult Guncelle(int ID)
        {
            Urun urun = database.GetForID(ID);
            ViewBag.Adi = urun.Adi;
            ViewBag.Aciklama = urun.Aciklama;
            ViewBag.Barkod = urun.Barkod;
            ViewBag.BaslangicTarih = urun.BaslangicTarih;
            ViewBag.BitisTarih = urun.BitisTarih;
            ViewBag.Fiyat = urun.Fiyat;
            ViewBag.EskiFiyat = urun.EskiFiyat;
            ViewBag.Maliyet = urun.Maliyet;
            ViewBag.KargoFiyat = urun.KargoFiyat;
            ViewBag.KargoDurum = urun.Agirlik;
            ViewBag.Uzunluk = urun.Uzunluk;
            ViewBag.Genislik = urun.Genislik;
            ViewBag.Yukseklik = urun.Yukseklik;
            ViewBag.Ureticiler = urun.Ureticiler;
            return View("UrunEkle", urun);
        }
    }
}