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
    public class ProcessController : Controller
    {
        private WFTestingEntities db = new WFTestingEntities();

        //
        // GET: /Process/

        public ActionResult Index()
        {
            var processes = db.Processes.Include(p => p.Form);
            return View(processes.ToList());
        }

        //
        // GET: /Process/Details/5

        public ActionResult Details(int id = 0)
        {
            Process process = db.Processes.Find(id);
            if (process == null)
            {
                return HttpNotFound();
            }
            return View(process);
        }

        //
        // GET: /Process/Create

        public ActionResult Create()
        {
            ViewBag.Form_Id = new SelectList(db.Forms, "Form_Id", "Form_Name");
            return View();
        }

        //
        // POST: /Process/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Process process)
        {
            if (ModelState.IsValid)
            {
                db.Processes.Add(process);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Form_Id = new SelectList(db.Forms, "Form_Id", "Form_Name", process.Form_Id);
            return View(process);
        }

        //
        // GET: /Process/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Process process = db.Processes.Find(id);
            if (process == null)
            {
                return HttpNotFound();
            }
            ViewBag.Form_Id = new SelectList(db.Forms, "Form_Id", "Form_Name", process.Form_Id);
            return View(process);
        }

        //
        // POST: /Process/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Process process)
        {
            if (ModelState.IsValid)
            {
                db.Entry(process).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Form_Id = new SelectList(db.Forms, "Form_Id", "Form_Name", process.Form_Id);
            return View(process);
        }

        //
        // GET: /Process/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Process process = db.Processes.Find(id);
            if (process == null)
            {
                return HttpNotFound();
            }
            return View(process);
        }

        //
        // POST: /Process/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Process process = db.Processes.Find(id);
            db.Processes.Remove(process);
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