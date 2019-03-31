using E_Mall.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

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
    }
}