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

//namespace BugTracker23.Helpers
//{
//    public class HistoryHelper
//    {
//        public void ManageHistories(Ticket oldTicket, Ticket newTicket)
//        {
//            DeveloperUpdate(oldTicket, newTicket);
//            PriorityUpdate(oldTicket, newTicket);
//            StatusUpdate(oldTicket, newTicket);
//            TypeUpdate(oldTicket, newTicket);
//            db.SaveChanges();
//        }

//        public void DeveloperUpdate(Ticket oldTicket, Ticket newTicket)
//        {
//            if (oldTicket.DeveloperId != newTicket.DeveloperId)
//            {
//                var history = new TicketHistory()
//                {
//                    TicketId = newTicket.Id,
//                    UserId = HttpContext.Current.User.Identity.GetUserId(),
//                    Property = "Developer",
//                    OldValue = oldTicket.DeveloperId == null ? "No Developer Assigned" : oldTicket.Developer.FullName,
//                    NewValue = newTicket.DeveloperId == null ? "No Developer Assigned" : newTicket.Developer.FullName,
//                    Updated = DateTime.Now
//                };

//            }
//        }
//        private void PriorityUpdate(Ticket oldTicket, Ticket newTicket)
//        {
//            if (oldTicket.TicketPriorityId != newTicket.TicketPriorityId)
//            {
//                var history = new TicketHistory()
//                {
//                    TicketId = newTicket.Id,
//                    UserId = HttpContext.Current.User.Identity.GetUserId(),
//                }
//            }
//        }

//        private void DeveloperUpdate(Ticket oldTicket, Ticket newTicket)
//        private void PriorityUpdate(Ticket oldTicket, Ticket newTicket)
//        private void StatusUpdate(Ticket oldTicket, Ticket newTicket)
//        private void TypeUpdate(Ticket oldTicket, Ticket newTicket)
//        private void TitleUpdate(Ticket oldTicket, Ticket newTicket)
//        private void DeveloperUpdate(Ticket oldTicket, Ticket newTicket)
//    }
//}