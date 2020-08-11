using BugTracker23.Helpers;
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
        private RoleHelper roleHelper = new RoleHelper();
        // GET: Users
        public ActionResult Index()
        {
            
            return View(db.Users.ToList());
        }
        public ActionResult ManageUserRole(string id)
        {
            //Does the user already occupy a role? If so, I need to display it;
            var userRole = roleHelper.ListUserRoles(id).FirstOrDefault(); 
            ViewBag.RoleName = new SelectList(db.Roles, "Name", "Name", userRole);
            return View(db.Users.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageUserRole(string id, string roleName)
        {
            //Spin through all the roles for this user and remove them;
            foreach(var role in roleHelper.ListUserRoles(id))
            { 
                roleHelper.RemoveUserFromRole(id, role);
            }
            if(!string.IsNullOrEmpty(roleName))
            {
                roleHelper.AddUserToRole(id, roleName);
            }
            return RedirectToAction("ManageUserRole", new { id });



            //Code in here looks very similar to the code we've already seen;
          //I need to remove all roles from this suer and add back the chosen role










        }
    }
}