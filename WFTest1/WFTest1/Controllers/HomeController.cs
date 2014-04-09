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
        private WFTest1Entities db = new WFTest1Entities();
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
            return View();
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

        public ActionResult User()
        {
            return View();
        }
        public ActionResult AddDesig()
        {
            return View();
        }

        public ActionResult Department()
        {
            return View();
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




    }
}
