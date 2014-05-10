using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WFTest1.Models;

namespace WFTest1.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        private TCSEntities db = new TCSEntities();
        public ActionResult Index()
        {
            string name = User.Identity.Name;
            List<Pending> pee;
            //var obj=new Pending
            var id = (from r in db.UserProfiles where r.UserName == name select r.UserId).First();
            var role_id = (from r in db.webpages_UsersInRoles where r.UserId == id select r.RoleId).First();
            var a = from p in db.Form_Divsion where p.RoleId == role_id select p;

            
            foreach(var pending in a)
            {
            var fp_id = (from q in db.Pendings where q.FD_ID == pending.FD_ID && q.FormId == pending.FormId select q);
           

            }        
            //ViewBag.check = fp_id.First();
            
           // ViewData["check"] = pee;
            return View(pee);
            
        }

    }
}
