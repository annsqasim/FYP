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
    public class FieldsController : Controller
    {
        private WFTestingEntities db = new WFTestingEntities();

        //
        // GET: /Fields/

        public ActionResult Index()
        {
            var fields = db.Fields.Include(f => f.Form).Include(f => f.Role);
            return View(fields.ToList());
        }

        //
        // GET: /Fields/Details/5

        public ActionResult Details(int id = 0)
        {
            Field field = db.Fields.Find(id);
            if (field == null)
            {
                return HttpNotFound();
            }
            return View(field);
        }

        //
        // GET: /Fields/Create

        public ActionResult Create()
        {
            ViewBag.Form_Id = new SelectList(db.Forms, "Form_Id", "Form_Name");
            ViewBag.Role_Id = new SelectList(db.Roles, "Role_Id", "Role_Name");
            return View();
        }

        //
        // POST: /Fields/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Field field)
        {
            if (ModelState.IsValid)
            {
                db.Fields.Add(field);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Form_Id = new SelectList(db.Forms, "Form_Id", "Form_Name", field.Form_Id);
            ViewBag.Role_Id = new SelectList(db.Roles, "Role_Id", "Role_Name", field.Role_Id);
            return View(field);
        }

        //
        // GET: /Fields/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Field field = db.Fields.Find(id);
            if (field == null)
            {
                return HttpNotFound();
            }
            ViewBag.Form_Id = new SelectList(db.Forms, "Form_Id", "Form_Name", field.Form_Id);
            ViewBag.Role_Id = new SelectList(db.Roles, "Role_Id", "Role_Name", field.Role_Id);
            return View(field);
        }

        //
        // POST: /Fields/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Field field)
        {
            if (ModelState.IsValid)
            {
                db.Entry(field).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Form_Id = new SelectList(db.Forms, "Form_Id", "Form_Name", field.Form_Id);
            ViewBag.Role_Id = new SelectList(db.Roles, "Role_Id", "Role_Name", field.Role_Id);
            return View(field);
        }

        //
        // GET: /Fields/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Field field = db.Fields.Find(id);
            if (field == null)
            {
                return HttpNotFound();
            }
            return View(field);
        }

        //
        // POST: /Fields/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Field field = db.Fields.Find(id);
            db.Fields.Remove(field);
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