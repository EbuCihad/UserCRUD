using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSKB.BusinessLayer;
using TSKB.Entities;

namespace TSKB.WebApp.Controllers
{
    public class HomeController : Controller
    {
        KisiManager ks = new KisiManager();
        SubeManager repoSube = new SubeManager();
        DepartmanManager repoDepartman = new DepartmanManager();
        EkipManager repoEkip = new EkipManager();



        // GET: Home
        public ActionResult Index()
        {
           
            return View();
        }


        public ActionResult AddKisi()
        {
            ViewBag.unit = new SelectList(repoSube.GetSubes(),"Id","isim");
            ViewBag.unit1 = new SelectList(repoDepartman.GetDepartmans(),"Id","isim");
            ViewBag.unit2 = new SelectList(repoEkip.GetEkips(),"Id","isim");

            return View(new Kisi());
        }

        [HttpPost]
        public ActionResult AddKisi(Kisi model, int subedrop, int departmandrop, int ekipdrop)
        {          
            ks.AddKisi( model,  subedrop,  departmandrop,  ekipdrop);
            return RedirectToAction("Index","Home");
        }

        public ActionResult UpdateKisi(int? Id)
        {
            ViewBag.unit = new SelectList(repoSube.GetSubes(), "Id", "isim");
            ViewBag.unit1 = new SelectList(repoDepartman.GetDepartmans(), "Id", "isim");
            ViewBag.unit2 = new SelectList(repoEkip.GetEkips(), "Id", "isim");
            return View(ks.GetKisis().Where(x => x.Id == Id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult UpdateKisi(Kisi model, int subedrop, int departmandrop, int ekipdrop)
        {
            ks.UpdateKisi(model, subedrop, departmandrop, ekipdrop);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteKisi(int? Id)
        {
            ks.DeleteKisi(Id);
            return RedirectToAction("Index", "Home");
        }

    }
}