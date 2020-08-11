using BugTracker23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker23.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Users
        public ActionResult Index()
        {
            
            return View(db.Users.ToList());
        }
        public ActionResult ManageUserRole(string id)
        {
            ViewBag.RoleName = new SelectList(db.Roles, "Name", "Name");
            return View(db.Users.Find(id));
        }
    }
}