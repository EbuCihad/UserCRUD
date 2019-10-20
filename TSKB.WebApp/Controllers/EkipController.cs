using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSKB.BusinessLayer;
using TSKB.Entities;

namespace TSKB.WebApp.Controllers
{
    public class EkipController : Controller
    {
        KisiManager ks = new KisiManager();
        SubeManager repoSube = new SubeManager();
        DepartmanManager repoDepartman = new DepartmanManager();
        EkipManager repoEkip = new EkipManager();
        // GET: Ekip
        public ActionResult Index(int? Id)
        {
            if (Id == 1)
            {
                ViewBag.dolu = 1;
            }
            else
            {
                ViewBag.dolu = 0;
            }
            return View();
        
        }

        public ActionResult AddEkip()
        {
            ViewBag.unit = new SelectList(repoSube.GetSubes(), "Id", "isim");
            ViewBag.unit1 = new SelectList(repoDepartman.GetDepartmans(), "Id", "isim");
            
            return View(new Ekip());
        }


        [HttpPost]
        public ActionResult AddEkip(Ekip model, int subedrop, int departmandrop)
        {
            repoEkip.AddEkip(model,subedrop,departmandrop);

            return RedirectToAction("Index", "Ekip");
        }


        public ActionResult UpdateEkip(int? Id)
        {
            ViewBag.unit = new SelectList(repoSube.GetSubes(), "Id", "isim");
            ViewBag.unit1 = new SelectList(repoDepartman.GetDepartmans(), "Id", "isim");
            return View(repoEkip.GetEkips().Where(x => x.Id == Id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult UpdateEkip(Ekip model, int subedrop, int departmandrop)
        {
            repoEkip.UpdateEkip(model, subedrop, departmandrop);
            return RedirectToAction("Index", "Ekip");
        }


        public ActionResult DeleteEkip(int? Id)
        {
            int i = repoEkip.DeleteEkip(Id);

            if (i == 1)
            {
                return RedirectToAction("Index", "Ekip");
            }
            else
            {

                return RedirectToAction("Index", "Ekip", new { Id = 1 });
            }
        }
    }
}