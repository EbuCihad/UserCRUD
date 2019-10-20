using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSKB.BusinessLayer;
using TSKB.Entities;

namespace TSKB.WebApp.Controllers
{
    public class SubeController : Controller
    {
        KisiManager ks = new KisiManager();
        SubeManager repoSube = new SubeManager();
        DepartmanManager repoDepartman = new DepartmanManager();
        EkipManager repoEkip = new EkipManager();
        // GET: Sube
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

        public ActionResult AddSube(int? Id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSube(Sube model)
        {
            repoSube.AddSube(model);
            return RedirectToAction("Index","Sube");
        }

        public ActionResult UpdateSube(int? Id)
        {
            return View(repoSube.GetSubes().Where(x=>x.Id==Id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult UpdateSube(Sube sube)
        {
            repoSube.UpdateSube(sube);
            return RedirectToAction("Index", "Sube");
        }

        public ActionResult DeleteSube(int? Id)
        {
            int i = repoSube.DeleteSube(Id);
            if (i==1)
            {
                return RedirectToAction("Index", "Sube");
            }
            else
            {
                
                return RedirectToAction("Index", "Sube",new { Id=1});
            }
            
            
        }
    }
}