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
    public class FormController : Controller
    {
        private EmpDept db = new EmpDept();

        //
        // GET: /Form/

        public ActionResult Index()
        {
            return View(db.forms.ToList());
        }

        //
        // GET: /Form/Details/5

        public ActionResult Details(int id = 0)
        {
            form form = db.forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        //
        // GET: /Form/Create

        public ActionResult passing()
        {
            return View();
        }

        //
        // POST: /Form/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult passing(form form)
        {
            if (ModelState.IsValid)
            {
                db.forms.Add(form);
                db.SaveChanges();
                
                //return RedirectToAction("Index");
            }

            return View(form);
        }

        //
        // GET: /Form/Edit/5

        public ActionResult Edit(int id = 0)
        {
            form form = db.forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        //
        // POST: /Form/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(form form)
        {
            if (ModelState.IsValid)
            {
                db.Entry(form).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(form);
        }

        //
        // GET: /Form/Delete/5

        public ActionResult Delete(int id = 0)
        {
            form form = db.forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        //
        // POST: /Form/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            form form = db.forms.Find(id);
            db.forms.Remove(form);
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