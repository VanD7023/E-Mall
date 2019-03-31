using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace E_Mall.Controllers
{
    public class UrunController : Controller
    {
        public ActionResult UrunYonetim()
        {
            return View();
        }
        public ActionResult UrunEkle()
        {
            return View();
        }
    }
}