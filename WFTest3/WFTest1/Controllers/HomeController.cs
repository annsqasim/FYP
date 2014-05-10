using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WFTest1.Models;
namespace WFTest1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
       private TCSEntities db = new TCSEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult InitiateProcess()
        {
            var forms = db.Forms;

            return View(forms.ToList());
        }
        public ActionResult InitiatedWorkflows()
        {
            return View();
        }

        public ActionResult InvolvedWorkflow()
        {
            return View();
        }

        public ActionResult WorkflowRecords()
        {
            return View();
        }
        public ActionResult DeleteDept()
        {
            return View();
        }

        //public ActionResult User()
        //{
        //    return View();
        //}
        public ActionResult AddDesig()
        {
            return View();
        }

        public ActionResult Department()
        {
            return View();
        }

        public ActionResult temp()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RoleInformation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RoleInformation(webpages_Roles roles)
        {
            if (ModelState.IsValid)
            {
                db.webpages_Roles.Add(roles);
                db.SaveChanges();
                return RedirectToAction("Designer");
            }

            return View();
           
        }
        public ActionResult Change_Request()
        {
            return View();
        }
        public ActionResult UserIndex()
        {
            return View();
        }
        public ActionResult UserInitiateProcess()
        {
            return View();
        }
        public ActionResult UserInitiatedWorkflows()
        {
            return View();
        }
        public ActionResult UserWorklfowRecoeds()
        {
            return View();
        }
        public ActionResult Monitoring()
        {
            return View();
        }
        public ActionResult Requistion_Authorization()
        {
            return View();
        }
        public ActionResult RMR()
        {
            return View();
        }

        public ActionResult Designer()
        {
            return View();
        }
        public ActionResult User()
        {
            return RedirectToAction("Register", "Account");
        }
        //[HttpPost]

        //[ValidateAntiForgeryToken]
        //public ActionResult Department(Department department)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //        //db.Departments.Add(department);
        //        //db.SaveChanges();
        //        return View("abc");
        //    //}

        //    //return View(department);
        //}
        [HttpGet]
        public ActionResult Designer(int id)
        {
            var count = (from r in db.Form_Divsion
                         where r.FormId == id
                         select r).Count();
            ViewBag.id = id;
            ViewBag.count = count;
            ViewBag.R_id = new SelectList(db.webpages_Roles, "RoleId", "RoleName");
            ViewBag.backState = new SelectList(db.webpages_Roles, "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        public ActionResult Designer(Activity activity, int id)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Designer");
            }

            ViewBag.R_id = new SelectList(db.webpages_Roles, "RoleId", "RoleName", activity.RoleId);
            ViewBag.backState = new SelectList(db.webpages_Roles, "RoleId", "RoleName", activity.BackState);
            return View(activity);
        }
        [HttpGet]
        public ActionResult Start(int formid)
        {

            AddmissionInstance adm = new AddmissionInstance();
            adm.FormId = formid;
            db.AddmissionInstances.Add(adm);
            db.SaveChanges();
            var q = (from r in db.AddmissionInstances where r.FormId == formid select r.AddmissionId).Max();
            Pending pen = new Pending();
            pen.FD_ID = 1;
            pen.FormId = formid;
            pen.InstanceId = q;
            db.Pendings.Add(pen);
            db.SaveChanges();
            return View();

        }

    }
}
