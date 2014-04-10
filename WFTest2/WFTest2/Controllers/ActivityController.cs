using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WFTest2.Models;

namespace WFTest2.Controllers
{
    public class ActivityController : Controller
    {
        private WFTestingEntities db = new WFTestingEntities();

        //
        // GET: /Activity/

        public ActionResult Index()
        {
            var activities = db.Activities.Include(a => a.Process);
            return View(activities.ToList());
        }

        //
        // GET: /Activity/Details/5

        public ActionResult Details(int id = 0)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        //
        // GET: /Activity/Create

        public ActionResult Create()
        {
            ViewBag.Process_Id = new SelectList(db.Processes, "Process_Id", "Proces_Name");
            return View();
        }

        //
        // POST: /Activity/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Process_Id = new SelectList(db.Processes, "Process_Id", "Proces_Name", activity.Process_Id);
            return View(activity);
        }

        //
        // GET: /Activity/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.Process_Id = new SelectList(db.Processes, "Process_Id", "Proces_Name", activity.Process_Id);
            return View(activity);
        }

        //
        // POST: /Activity/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Process_Id = new SelectList(db.Processes, "Process_Id", "Proces_Name", activity.Process_Id);
            return View(activity);
        }

        //
        // GET: /Activity/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        //
        // POST: /Activity/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
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