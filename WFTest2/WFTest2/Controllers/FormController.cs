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
    public class FormController : Controller
    {
        private WFTestingEntities db = new WFTestingEntities();

        //
        // GET: /Form/

        public ActionResult Index()
        {
            return View(db.Forms.ToList());
        }

        //
        // GET: /Form/Details/5

        public ActionResult Details(int id = 0)
        {
            Form form = db.Forms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }
            return View(form);
        }

        //
        // GET: /Form/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Form/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Form form)
        {
            if (ModelState.IsValid)
            {
                db.Forms.Add(form);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(form);
        }

        //
        // GET: /Form/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Form form = db.Forms.Find(id);
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
        public ActionResult Edit(Form form)
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
            Form form = db.Forms.Find(id);
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
            Form form = db.Forms.Find(id);
            db.Forms.Remove(form);
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