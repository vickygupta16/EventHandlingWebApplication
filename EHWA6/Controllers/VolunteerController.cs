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
    public class VolunteerController : Controller
    {
        private EH6DbContext db = new EH6DbContext();

        //
        // GET: /Volunteer/
        public ActionResult EventsList()
        {
            var evs = db.evs.Include(e => e.orgs);
            return View(evs.ToList());
        }
        public ActionResult Restriction()
        {
            return View();
        }
        public ActionResult Index()
        {
            if (User.Identity.Name != "Administrator")
            {
                var vols = db.vols.Include(v => v.evs).Include(v => v.ups);
                return View(vols.ToList());
            }
            else
            {
                return RedirectToAction("Restriction");
            }
        }

        //
        // GET: /Volunteer/Details/5

        public ActionResult Details(int id = 0)
        {
            Volunteer volunteer = db.vols.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        //
        // GET: /Volunteer/Create

        public ActionResult Create()
        {
            if (User.Identity.Name != "Administrator")
            {
                ViewBag.EventsId = new SelectList(db.evs, "EventsId", "EventName");
                ViewBag.UserId = new SelectList(db.UserProfiles.Where(x => x.UserName == User.Identity.Name), "UserId", "UserName");
                return View();
            }
            else
            {
                return RedirectToAction("Restriction");
            }
        }

        //
        // POST: /Volunteer/Create

        [HttpPost]
        public ActionResult Create(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.vols.Add(volunteer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventsId = new SelectList(db.evs, "EventsId", "EventName", volunteer.EventsId);
            ViewBag.UserId = new SelectList(db.UserProfiles.Where(x => x.UserName == User.Identity.Name), "UserId", "UserName", volunteer.UserId);
            return View(volunteer);
        }

        //
        // GET: /Volunteer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Volunteer volunteer = db.vols.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventsId = new SelectList(db.evs, "EventsId", "EventName", volunteer.EventsId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", volunteer.UserId);
            return View(volunteer);
        }

        //
        // POST: /Volunteer/Edit/5

        [HttpPost]
        public ActionResult Edit(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventsId = new SelectList(db.evs, "EventsId", "EventName", volunteer.EventsId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", volunteer.UserId);
            return View(volunteer);
        }

        //
        // GET: /Volunteer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Volunteer volunteer = db.vols.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        //
        // POST: /Volunteer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Volunteer volunteer = db.vols.Find(id);
            db.vols.Remove(volunteer);
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