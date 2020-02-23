using EHWA6.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EHWA6.Controllers
{
    public class HomeController : Controller
    {
        private EH6DbContext db = new EH6DbContext();

        public ActionResult Restricted()
        {
            return View();
        }

        public ActionResult Index()
        {
            if (User.Identity.Name == "Administrator")
            {
                return RedirectToAction("AdminIndex");
            }
            else
            {
                return View();
            }
        }

        public ActionResult AdminIndex()
        {
            return View();
        }

        public ActionResult About()
        {
            if (User.Identity.Name == "Administrator")
            {
                return RedirectToAction("AdminAbout");
            }
            else
            {
                return View();
            }
        }

        public ActionResult AdminAbout()
        {
            return View();
        }

        public ActionResult Contact()
        {
            if (User.Identity.Name == "Administrator")
            {
                return RedirectToAction("AdminContact");
            }
            else
            {
                return View();
            }
        }

        public ActionResult AdminContact()
        {
            return View();
        }

        [Authorize]
        public ActionResult Data()
        {
            List<object> mymodel = new List<object>();
            mymodel.Add(db.UserProfiles.ToList());
            mymodel.Add(db.orgs.ToList());
            mymodel.Add(db.evs.ToList());
            mymodel.Add(db.vols.ToList());
            return View(mymodel);
        }
    }
}
