using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        dbmvcokulEntities1 db = new dbmvcokulEntities1();
        public ActionResult Index()
        {
            var ogr = db.TBLOGRENCI.ToList();
            return View(ogr);
        }

        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUP.ToList()
                                             select new SelectListItem
                                             { 
                                                 Text = i.KULUPAD,                                                 
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();


            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCI p3)
        {
            var klp = db.TBLKULUP.Where(m => m.KULUPID >= p3.TBLKULUP.KULUPID).FirstOrDefault();
            p3.TBLKULUP = klp;
            db.TBLOGRENCI.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogr = db.TBLOGRENCI.Find(id);
            db.TBLOGRENCI.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBLOGRENCI.Find(id);
            return View("OgrenciGetir",ogrenci);
        }

        public ActionResult Guncelle(TBLOGRENCI p)
        {
            var ogrenci = db.TBLOGRENCI.Find(p.OGRENCIID);
            ogrenci.OGRAD = p.OGRAD;
            ogrenci.OGRSOYAD = p.OGRSOYAD;
            ogrenci.OGRFOTO = p.OGRFOTO;
            ogrenci.OGRCINSIYET = p.OGRCINSIYET;
            ogrenci.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }
    }
}