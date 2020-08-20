using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugTracker23.Models;
using BugTracker23.Helpers;

namespace BugTracker23.Controllers
{
    public class AssignmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleHelper roleHelper = new RoleHelper();
        private ProjectHelper projectHelper = new ProjectHelper();
        //GET: Assignments
        [Authorize(Roles = "Administrator")]
        #region Role Assignments        
        public ActionResult ManageRoles()
        {
            //User my ViewBag to hold a multi select list of Users in the system
            ViewBag.UserIds = new MultiSelectList(db.Users, "Id", "Email");

            //Use my ViewBag to hold a select list of Roles
            ViewBag.RoleName = new SelectList(db.Roles.Where(r => r.Name != "Administrator"), "Name", "Name");
            return View(db.Users.ToList());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageRoles(List<string> userIds, string roleName)
        {

            //Step 1: If anyone was selected...remove them from all of their roles
            if (userIds == null)
                return RedirectToAction("RolesIndex");

            //Step 2: If anyone was selected...
            foreach (var userId in userIds)
            {
                //Determine if this user occupies a role
                foreach (var role in roleHelper.ListUserRoles(userId).ToList())
                {
                    roleHelper.RemoveUserFromRole(userId, role);
                }

                if (!string.IsNullOrEmpty(roleName))
                {
                    roleHelper.AddUserToRole(userId, roleName);
                }
            }
            return RedirectToAction("ManageRoles");
        }
        #endregion

        #region Project Assignments
        public ActionResult ManageProjectUsers()
        {
            //I want to List Boxes in my View...therefore I want to load up 2 multi Select Lists
            ViewBag.UserIds = new MultiSelectList(db.Users, "Id", "Email");

            ViewBag.ProjectIds = new MultiSelectList(db.Projects, "Id", "Name");

            return View(db.Users.ToList());

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageProjectUsers(List<string> userIds, List<int> projectIds)
        {
            //Case 1: NO Users and No Projects
            if (userIds == null && projectIds == null)
            {
                return RedirectToAction("ManageProjectUsers");
            }
            //Iterate over each user and them to each of the projects
            foreach (var userId in userIds)
            {
                //Assign this person to each project
                foreach (var projectId in projectIds)
                {
                    projectHelper.AddUserToProject(userId, projectId);
                }
            }
            return RedirectToAction("ManageProjectUsers");
            #endregion
        }
    }
}