using BugTracker23.Models;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Runtime.CompilerServices;

namespace BugTracker23.Helpers
{
    public class ProjectHelper
    #region Project Helper Description
    //What do we need to do? - Manage projects and who is assigned to the project.
    //Remove one or more users from a project - 
    //Add one or more users to a project - 
    //List Users on a project - 
    //Boolean method IsUserOnProject
    //Optional: List users on a project that occupy a specific role
    //Optional: List users not on a project in a specific role
    //Optional: List projects for a specific user
    //Optional: Filer for Project Manager role - if you code for only
    #endregion
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        #region : Is User on Project
        public bool IsUserOnProject(string userId, int projectId)
        {
            var project = db.Projects.Find(projectId);
            var flag = project.Users.Any(u => u.Id == userId);
            return (flag);
            //Project project = db.Projects.Find(projectId);
            //var user = db.Users.Find(userId);
            //return project.Users.Contains(user);
        }
        #endregion

        #region : List User Projects
        public ICollection<Project> ListUserProjects(string userId)
        {
            ApplicationUser user = db.Users.Find(userId);
            var projects = user.Projects.ToList();
            return (projects);
        }
        #endregion

        #region : Add User(s) to Project
        public void AddUserToProject(string userId, int projectId)
        {
            if (!IsUserOnProject(userId, projectId))
            {
                Project project = db.Projects.Find(projectId);
                var newUser = db.Users.Find(userId);
                project.Users.Add(newUser);
                db.SaveChanges();
            }
        }
        #endregion

        #region : Remove User(s) From Project

        public void RemoveUserFromProject(string userId, int projectId)
        {
            if (IsUserOnProject(userId, projectId))
            {
                Project project = db.Projects.Find(projectId);
                var delUser = db.Users.Find(userId);

                project.Users.Remove(delUser);
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        #endregion

        #region : Users On Project
        public ICollection<ApplicationUser> UsersOnProject(int projectId)
        {
            return db.Projects.Find(projectId).Users;
        }
        #endregion

        #region : Users Not On Project

        public ICollection<ApplicationUser> UsersNotOnProject(int projectId)
        {
            return db.Users.Where(u => u.Projects.All(p => p.Id != projectId)).ToList();
        }
        #endregion
    }
}