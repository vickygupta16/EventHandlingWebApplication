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
    public class EventsController : Controller
    {
        private EH6DbContext db = new EH6DbContext();

        //
        // GET: /Events/

        public ActionResult Index()
        {
            if (User.Identity.Name == "Administrator")
            {
                var evs = db.evs.Include(e => e.orgs);
                return View(evs.ToList());
            }
            else
            {
                return RedirectToAction("Restricted", "Home");
            }
        }

        //
        // GET: /Events/Details/5

        public ActionResult Details(int id = 0)
        {
            Events events = db.evs.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        //
        // GET: /Events/Create

        public ActionResult Create()
        {
            if (User.Identity.Name == "Administrator")
            {
                ViewBag.OrganizationId = new SelectList(db.orgs, "OrganizationId", "OrganizationName");
                return View();
            }
            else
            {
                return RedirectToAction("Restricted", "Home");
            }
        }

        //
        // POST: /Events/Create

        [HttpPost]
        public ActionResult Create(Events events)
        {
            if (ModelState.IsValid)
            {
                db.evs.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = new SelectList(db.orgs, "OrganizationId", "OrganizationName", events.OrganizationId);
            return View(events);
        }

        //
        // GET: /Events/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Events events = db.evs.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = new SelectList(db.orgs, "OrganizationId", "OrganizationName", events.OrganizationId);
            return View(events);
        }

        //
        // POST: /Events/Edit/5

        [HttpPost]
        public ActionResult Edit(Events events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = new SelectList(db.orgs, "OrganizationId", "OrganizationName", events.OrganizationId);
            return View(events);
        }

        //
        // GET: /Events/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Events events = db.evs.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        //
        // POST: /Events/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Events events = db.evs.Find(id);
            db.evs.Remove(events);
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