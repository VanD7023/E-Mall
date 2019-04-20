using E_Mall.Database;
using E_Mall.Models;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace E_Mall.Controllers
{
    public class UrunOzellikleriController : Controller
    {
        UrunOzellikleriDatabase database;
        public UrunOzellikleriController()
        {
            database = new UrunOzellikleriDatabase();
        }
        public ActionResult Index()
        {
            return View(database.GetAll());
        }
        [HttpPost]
        public ActionResult Olustur(UrunOzellikleri item)
        {
            database.Insert(item);
            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Guncelle(UrunOzellikleri item)
        {
            database.Update(item);
            return Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);
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