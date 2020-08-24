using BugTracker23.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker23.Helpers
{
    public class TicketManager
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleHelper roleHelper = new RoleHelper();
        public List<Ticket> GetMyTickets()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var tickets = new List<Ticket>();
            var myRole = roleHelper.ListUserRoles(userId).FirstOrDefault();
            switch (myRole)
            {
                case "Administrator":
                    tickets.AddRange(db.Tickets);
                    break;
                case "Project Manager":
                    tickets.AddRange(db.Users.Find(userId).Projects.SelectMany(p => p.Tickets));
                    break;
                case "Developer":
                    tickets.AddRange(db.Tickets.Where(t => t.DeveloperId == userId));
                    break;
                case "Submitter":
                    tickets.AddRange(db.Tickets.Where(t => t.SubmitterId == userId));
                    break;
                default:
                    break;
            }
            return tickets;
        }
    }
}