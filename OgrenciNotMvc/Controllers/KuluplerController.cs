using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
namespace OgrenciNotMvc.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        dbmvcokulEntities1 db = new dbmvcokulEntities1();
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUP.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {

            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(TBLKULUP p2)
        {
            db.TBLKULUP.Add(p2);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUP.Find(id);
            db.TBLKULUP.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulupGetir(int id)
        {
            var klp2 = db.TBLKULUP.Find(id);
            return View("KulupGetir",klp2);
        }

        public ActionResult Guncelle(TBLKULUP p)
        {
            var klp = db.TBLKULUP.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}