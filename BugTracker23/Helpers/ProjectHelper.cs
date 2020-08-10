using BugTracker23.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace BugTracker23.Helpers
{
    public class ProjectHelper
    #region Description
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

        public void AddUserToProject(string userId, int projectId) 
        {
            Project project = db.Projects.Find(projectId);
            var user = db.Users.Find(userId);
            project.Users.Add(user);
        }
        public bool RemoveUserFromProject(string userId, int projectId)
        {
            Project project = db.Projects.Find(projectId);
            var user = db.Users.Find(userId);
            var result = project.Users.Remove(user);
            return result;
        }
        public ICollection<ApplicationUser> ListUsersOnProject(int projectId)
        {
            Project project = db.Projects.Find(projectId);
            var resultList = new List<ApplicationUser>();
            resultList.AddRange(project.Users);
            return resultList;
        }
        public List<ApplicationUser> ListUsersNotOnProject(int projectId)
        {
            var resultList = new List<ApplicationUser>();
            foreach(var user in db.Users.ToList())
            {
                if(!IsUserOnProject(user.Id, projectId))
                {
                    resultList.Add(user);
                }
            }
            return resultList;
        }
        public bool IsUserOnProject(string userId, int projectId)
        {
            Project project = db.Projects.Find(projectId);
            var user = db.Users.Find(userId);
            return project.Users.Contains(user);
        }
        public List<Project> ListUserProjects(string userId)
        {
            var user = db.Users.Find(userId);
            var resultList = new List<Project>();
            resultList.AddRange(user.Projects);
            return resultList;
        }

    }
}