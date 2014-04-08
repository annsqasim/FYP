using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity; 
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTesting.Models;

namespace MvcTesting.Controllers
{
    public class ActivityController : Controller
    {
        private MVCTestingEntities db = new MVCTestingEntities();
        public string selectedText { get; set; }

        //
        // GET: /Activity/

        public ActionResult Index()
        {
            
           // var activities = db.activities.Include(a => a.Emp1).Include(a => a.Process).Include(a => a.Emp);
            IEnumerable<SelectListItem> EmpNames = db.Emps.Select(c => new SelectListItem { Text = c.E_Name, Value = c.E_ID.ToString() });
            ViewBag.EmpList = EmpNames;
            return View();
            
        }

        //
        // GET: /Activity/Details/5

        public ActionResult Details(int id = 0)
        {
            activity activity = db.activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        //
        // GET: /Activity/Create

        [HttpGet]
        public ActionResult Create()
        {

            List<activity> model = new List<activity>();

            using (EmpDept dc = new EmpDept())
            {

                model = dc.activities.ToList();

            }

            return View(model);

        }

        //public ActionResult Create()
        //{
        //    ViewBag.next_state = new SelectList(db.Emps, "E_ID", "E_Name");
        //    ViewBag.process_id = new SelectList(db.Processes, "Process_ID", "Process_Name");
        //    ViewBag.e_id = new SelectList(db.Emps, "E_ID", "E_Name");
        //    return View();
        //}

        //
        // POST: /Activity/Create
        [HttpPost]
        public ActionResult Index(List<activity> list)
        {



            if (ModelState.IsValid)
            {

                using (EmpDept dc = new EmpDept())
                {

                    foreach (var i in list)
                    {

                        var c = dc.activities.Where(a => a.A_ID.Equals(i.A_ID)).FirstOrDefault();

                        if (c != null)
                        {

                            c.E_ID = i.E_ID;

                            c.review = i.review;

                            c.Input = i.Input;

                            c.Decision = i.Decision;

                            c.next_state = i.next_state;

                            c.Process_ID = i.Process_ID;

                            c.Due_Date = i.Due_Date;

                        }

                    }

                    dc.SaveChanges();

                }

                ViewBag.Message = "Successfully Updated.";

                return View(list);

            }

            else
            {

                ViewBag.Message = "Failed ! Please try again.";

                return View(list);

            }

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(activity activity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.activities.Add(activity);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.next_state = new SelectList(db.Emps, "E_ID", "E_Name", activity.next_state);
        //    ViewBag.Process_ID = new SelectList(db.Processes, "Process_ID", "Process_Name", activity.Process_ID);
        //    ViewBag.E_ID = new SelectList(db.Emps, "E_ID", "E_Name", activity.E_ID);
        //    return View(activity);
        //}

        //
        // GET: /Activity/Edit/5

        public ActionResult Edit(int id = 0)
        {
            activity activity = db.activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.next_state = new SelectList(db.Emps, "E_ID", "E_Name", activity.next_state);
            ViewBag.Process_ID = new SelectList(db.Processes, "Process_ID", "Process_Name", activity.Process_ID);
            ViewBag.E_ID = new SelectList(db.Emps, "E_ID", "E_Name", activity.E_ID);
            return View(activity);
        }

        //
        // POST: /Activity/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.next_state = new SelectList(db.Emps, "E_ID", "E_Name", activity.next_state);
            ViewBag.Process_ID = new SelectList(db.Processes, "Process_ID", "Process_Name", activity.Process_ID);
            ViewBag.E_ID = new SelectList(db.Emps, "E_ID", "E_Name", activity.E_ID);
            return View(activity);
        }

        //
        // GET: /Activity/Delete/5

        public ActionResult Delete(int id = 0)
        {
            activity activity = db.activities.Find(id);
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
            activity activity = db.activities.Find(id);
            db.activities.Remove(activity);
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