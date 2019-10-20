using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSKB.BusinessLayer;
using TSKB.Entities;

namespace TSKB.WebApp.Controllers
{
    public class DepartmanController : Controller
    {
        KisiManager ks = new KisiManager();
        SubeManager repoSube = new SubeManager();
        DepartmanManager repoDepartman = new DepartmanManager();
        EkipManager repoEkip = new EkipManager();
        // GET: Departman
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

        public ActionResult AddDepartman()
        {
            ViewBag.unit = new SelectList(repoSube.GetSubes(), "Id", "isim");
            return View(new Departman());
        }

        [HttpPost]
        public ActionResult AddDepartman(Departman departman, int subedrop)
        {
            repoDepartman.AddDepartman(departman,subedrop);
            return RedirectToAction("Index", "Departman");
        }

        public ActionResult UpdateDepartman(int? Id)
        {
            ViewBag.unit = new SelectList(repoSube.GetSubes(), "Id", "isim");
            return View(repoDepartman.GetDepartmans().Where(x=>x.Id==Id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult UpdateDepartman(Departman model,int dropSube)
        {
            repoDepartman.UpdateDepartman(model, dropSube);
            return RedirectToAction("Index", "Departman");
        }


        public ActionResult DeleteDepartman(int? Id)
        {
            int i=repoDepartman.DeleteDepartman(Id);
           
            if (i == 1)
            {
                return RedirectToAction("Index", "Departman");
            }
            else
            {

                return RedirectToAction("Index", "Departman", new { Id = 1 });
            }

            
        }

    }
}