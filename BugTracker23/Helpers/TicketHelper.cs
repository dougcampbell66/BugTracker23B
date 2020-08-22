using Microsoft.AspNet.Identity;
using BugTracker23.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;

//Created on 8/13 via Drew; 

namespace BugTracker23.Helpers
{
    public class TicketHelper
    {
        private RoleHelper roleHelper = new RoleHelper();
        private ApplicationDbContext db = new ApplicationDbContext();
        //private HistoryHelper historyHelper = new HistoryHelper();
        public bool CanMakeComment(int ticketId)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var myRole = roleHelper.ListUserRoles(userId).FirstOrDefault();
            //var ticket = db.Tickets.Find(ticketId);
            switch (myRole)
            {
                case "Administrator":
                    return true;
                case "Project Manager":
                    var user = db.Users.Find(userId);
                    return user.Projects.SelectMany(p => p.Tickets).Any(t => t.Id == ticketId);
                case "Developer":
                case "Submitter":
                    var ticket = db.Tickets.Find(ticketId);
                    if (ticket.DeveloperId == userId || ticket.SubmitterId == userId)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }
        public bool CanEditComment(int ticketId)
    {
        var userId = HttpContext.Current.User.Identity.GetUserId();
        var myRole = roleHelper.ListUserRoles(userId).FirstOrDefault();
        var ticket = db.Tickets.Find(ticketId);
        switch (myRole)
        {
            case "Administrator":
                return true;
            case "Project Manager":
                var user = db.Users.Find(userId);
                return user.Projects.SelectMany(p => p.Tickets).Any(t => t.Id == ticketId);
            case "Developer":
            case "Submitter":
                //var ticket = db.Tickets.Find(ticketId);
                if (ticket.DeveloperId == userId || ticket.SubmitterId == userId)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            default:
                return false;
        }
    }

    public void ManageTicketNotifications(Ticket oldTicket, Ticket newTicket)
    {
        if (oldTicket.DeveloperId != newTicket.DeveloperId && newTicket.DeveloperId != null)
        {
            //I have determined that this particular change requires a notification
            var notification = new TicketNotification()
            {
                TicketId = newTicket.Id,
                UserId = newTicket.DeveloperId,
                Created = DateTime.Now,
                Subject = $"You have been assigned Ticket Id: { newTicket.Id}",
                Message = $"Heads up{newTicket.Developer.FullName}, you have been assigned a "

            };

            db.TicketNotifications.Add(notification);
            db.SaveChanges();
        }
    }
}
}