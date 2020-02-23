using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EHWA6.Models;
using EHWA6.DatabaseContext;

namespace EHWA6.Controllers
{
    [Authorize]
    public class OrganizationController : Controller
    {
        private EH6DbContext db = new EH6DbContext();

        //
        // GET: /Organization/


        public ActionResult Index()
        {
            if (User.Identity.Name == "Administrator")
            {
                return View(db.orgs.ToList());
            }
            else
            {
                return RedirectToAction("Restricted","Home");
            }
        }

        //
        // GET: /Organization/Details/5

        public ActionResult Details(int id = 0)
        {
            Organization organization = db.orgs.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        //
        // GET: /Organization/Create

        public ActionResult Create()
        {
            if (User.Identity.Name == "Administrator")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Restricted", "Home");
            }
        }

        //
        // POST: /Organization/Create

        [HttpPost]
        public ActionResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.orgs.Add(organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        //
        // GET: /Organization/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Organization organization = db.orgs.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        //
        // POST: /Organization/Edit/5

        [HttpPost]
        public ActionResult Edit(Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        //
        // GET: /Organization/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Organization organization = db.orgs.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        //
        // POST: /Organization/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = db.orgs.Find(id);
            db.orgs.Remove(organization);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}