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
    public class empController : Controller
    {
        private EmpDept db = new EmpDept();
        

        //
        // GET: /emp/

        public ActionResult Index()
        {
            var emps = db.Emps.Include(e => e.Dept);
            return View(emps.ToList());
        }

        //
        // GET: /emp/Details/5

        public ActionResult Details(int id = 0)
        {
            Emp emp = db.Emps.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        //
        // GET: /emp/Create

        public ActionResult Create()
        {
            ViewBag.Dept_ID = new SelectList(db.Depts, "Dept_ID", "Dept_Name");
            return View();
        }

        //
        // POST: /emp/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Emp emp)
        {
            if (ModelState.IsValid)
            {
                db.Emps.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dept_ID = new SelectList(db.Depts, "Dept_ID", "Dept_Name", emp.Dept_ID);
            return View(emp);
        }

        //
        // GET: /emp/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Emp emp = db.Emps.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dept_ID = new SelectList(db.Depts, "Dept_ID", "Dept_Name", emp.Dept_ID);
            return View(emp);
        }

        //
        // POST: /emp/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Emp emp)
        {

            if (ModelState.IsValid)
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dept_ID = new SelectList(db.Depts, "Dept_ID", "Dept_Name", emp.Dept_ID);
            return View(emp);
        }

        //
        // GET: /emp/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Emp emp = db.Emps.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        //
        // POST: /emp/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emp emp = db.Emps.Find(id);
            db.Emps.Remove(emp);
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